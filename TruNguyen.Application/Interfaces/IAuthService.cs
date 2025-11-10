using static TruNguyen.Application.DTOs.AuthDtos;

namespace TruNguyen.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken, string? ipAddress = null);
        Task RevokeRefreshTokenAsync(string refreshToken, string? ipAddress = null);
        Task RevokeAllForUserAsync(Guid userId); // optional
    }
}
