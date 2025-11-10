using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Application.Services;
using TruNguyen.Domain.Entities;
using static TruNguyen.Application.DTOs.AuthDtos;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService auth, ILogger<AuthController> logger) 
        { 
            _auth = auth;
            _logger = logger;
        } 


        // POST: /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            try
            {
                // Lấy địa chỉ IP của client đang gửi request login
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                // Gọi Service xác thực để đăng nhập
                var res = await _auth.LoginAsync(new LoginRequest(dto.Email, dto.Password, ip));
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }

        // POST: /api/auth/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest dto)
        {
            try
            {
                // Lấy địa chỉ IP của client đang gửi request login
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                // Gọi Service xác thực để làm mới token
                var res = await _auth.RefreshTokenAsync(dto.RefreshToken, ip);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }

        // POST: /api/auth/revoke
        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromBody] RefreshRequest dto)
        {
            try
            {
                // Lấy địa chỉ IP của client đang gửi request login
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                // Gọi Service xác thực để thu hồi token
                await _auth.RevokeRefreshTokenAsync(dto.RefreshToken, ip);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }

        // POST: /api/auth/revoke-all  (auth required)
        [HttpPost("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            try
            {
                /*
                 * Guid.TryParse 
                 * - để đảm bảo: Claim “sub” không bị giả mạo
                 * - Nếu không parse được thì trả về 401 Unauthorized
                 * 
                 * User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                 * - Mỗi JWT token có claim "sub" (subject) được khuyến nghị dùng để chứa UserId
                 * - Khi user đã login bằng JWT, request sẽ mang token → từ đó bạn lấy được claim này.
                 */
                if (!Guid.TryParse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value, out var userId))
                    return Unauthorized();

                // Gọi Service xác thực để thu hồi tất cả token của user
                await _auth.RevokeAllForUserAsync(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
    }
}
