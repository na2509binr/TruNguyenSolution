using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TruNguyen.Application.Interfaces;
using TruNguyen.Application.Settings;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _settings;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IOptions<JwtSettings> opts, ILogger<TokenService> logger)
        {
            _settings = opts.Value;
            _logger = logger;
        }


        public string GenerateAccessToken(User user)
        {
            try
            {
                // Tạo khóa bảo mật từ secret key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

                // Tạo chữ ký số
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tạo danh sách claim
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
                    // thêm claim role, name nếu cần
                };

                // Tạo token
                var token = new JwtSecurityToken(
                    issuer: _settings.Issuer,
                    audience: _settings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_settings.AccessTokenExpiryMinutes),
                    signingCredentials: creds
                );

                // Trả về chuỗi token
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return "";
            }
        }

        public string GenerateRefreshToken()
        {
            try
            {
                // Tạo mảng byte ngẫu nhiên
                var random = RandomNumberGenerator.GetBytes(64);

                // Trả về chuỗi Base64 của mảng byte
                return Convert.ToBase64String(random);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return "";
            }
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredAccessToken(string token)
        {
            try
            {
                // Thiết lập tham số xác thực token
                var tokenHandler = new JwtSecurityTokenHandler();

                // Lấy khóa bảo mật từ secret key
                var key = Encoding.UTF8.GetBytes(_settings.SecretKey);

                // Thiết lập tham số xác thực token
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _settings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = false // we want expired token claims
                };

                try
                {
                    // Xác thực token và lấy ClaimsPrincipal
                    var principal = tokenHandler.ValidateToken(token, parameters, out var securityToken);

                    /*
                     * securityToken is JwtSecurityToken jwt
                     * - Kiểm tra object securityToken có thật sự là JWT hay không.
                     * - Nếu đúng, ép kiểu sang JwtSecurityToken để đọc Header (thuật toán ký).
                     * 
                     * jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)
                     * - xác thực thuật toán ký có đúng không.
                     * 
                     */
                    if (securityToken is JwtSecurityToken jwt &&
                        jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return principal;
                    }
                }
                catch
                {
                    // invalid token
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null;
            }
        }
    }
}
