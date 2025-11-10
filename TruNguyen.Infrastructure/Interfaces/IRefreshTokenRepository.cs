using TruNguyen.Domain.Entities;

namespace TruNguyen.Infrastructure.Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, int>
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<IEnumerable<RefreshToken>> GetAllForUserAsync(Guid userId);
        Task RevokeAsync(RefreshToken token, string? replacedBy = null, string? revokedByIp = null);
        Task RemoveExpiredAsync(DateTime now); // optional cleanup
    }
}
