using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Application.DTOs
{
    public class AuthDtos
    {
        public record LoginRequest(string Email, string Password, string? Ip = null);
        public record AuthResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt);
        public record RefreshRequest(string RefreshToken, string? Ip = null);


    }
}
