using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Application.Interfaces;
using TruNguyen.Application.Settings;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;
using static TruNguyen.Application.DTOs.AuthDtos;

namespace TruNguyen.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRefreshTokenRepository _refreshRepo;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AuthService> _logger;


        public AuthService(
            IUserRepository userRepo,
            IRefreshTokenRepository refreshRepo,
            ITokenService tokenService,
            IOptions<JwtSettings> jwtOptions,
            ILogger<AuthService> logger)
        {
            _userRepo = userRepo;
            _refreshRepo = refreshRepo;
            _tokenService = tokenService;
            _jwtSettings = jwtOptions.Value;
            _logger = logger;
        }


        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                // Truy cập DB lấy bản ghi có Email tương ứng
                var user = await _userRepo.GetByEmailAsync(request.Email);

                // Kiểm tra user tồn tại và mật khẩu đúng
                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                    throw new UnauthorizedAccessException("Invalid credentials");

                // Tạo access token và refresh token
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshTokenValue = _tokenService.GenerateRefreshToken();

                // Lưu refresh token vào DB
                var refreshEntity = new RefreshToken
                {
                    Token = refreshTokenValue,
                    UserId = user.Id,
                    ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays),
                    CreatedByIp = request.Ip
                };

                // Lưu vào repository
                await _refreshRepo.AddAsync(refreshEntity);

                // Trả về AuthResponse
                return new AuthResponse(accessToken, refreshTokenValue, DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshTokenValue, string? ipAddress = null)
        {
            try
            {
                // Truy cập DB lấy bản ghi refresh token
                var stored = await _refreshRepo.GetByTokenAsync(refreshTokenValue);

                // Kiểm tra token hợp lệ
                if (stored == null || stored.IsRevoked || stored.ExpiresAt <= DateTime.UtcNow)
                    throw new UnauthorizedAccessException("Invalid refresh token");

                // Lấy user tương ứng
                var user = await _userRepo.GetByIdAsync(stored.UserId) ?? throw new UnauthorizedAccessException("User not found");

                // Tạo refresh token mới
                var newRefreshValue = _tokenService.GenerateRefreshToken();

                // Thu hồi token cũ và lưu token mới
                await _refreshRepo.RevokeAsync(stored, replacedBy: newRefreshValue, revokedByIp: ipAddress);

                // Tạo entity cho token mới
                var newRefreshEntity = new RefreshToken
                {
                    Token = newRefreshValue,
                    UserId = user.Id,
                    ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays),
                    CreatedByIp = ipAddress
                };

                // Lưu token mới vào repository
                await _refreshRepo.AddAsync(newRefreshEntity);

                // Tạo access token mới
                var newAccess = _tokenService.GenerateAccessToken(user);

                // Trả về AuthResponse
                return new AuthResponse(newAccess, newRefreshValue, DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task RevokeRefreshTokenAsync(string refreshTokenValue, string? ipAddress = null)
        {
            try
            {
                // Truy cập DB lấy bản ghi refresh token
                var stored = await _refreshRepo.GetByTokenAsync(refreshTokenValue);

                // Kiểm tra token hợp lệ
                if (stored == null) return;

                // Nếu token đã bị thu hồi thì không làm gì cả
                if (stored.IsRevoked) return;

                // Thu hồi token
                await _refreshRepo.RevokeAsync(stored, revokedByIp: ipAddress);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
            }
        }

        public async Task RevokeAllForUserAsync(Guid userId)
        {
            try
            {
                // Lấy tất cả refresh token của user
                var tokens = await _refreshRepo.GetAllForUserAsync(userId);

                // Thu hồi từng token
                foreach (var t in tokens.Where(x => !x.IsRevoked))
                {
                    await _refreshRepo.RevokeAsync(t);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
            }
        }
    }
}
