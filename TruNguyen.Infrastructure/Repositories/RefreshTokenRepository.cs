using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{

    public class RefreshTokenRepository : GenericRepository<RefreshToken, int>, IRefreshTokenRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<RefreshTokenRepository> _logger;

        public RefreshTokenRepository(AppDbContext context, ILogger<RefreshTokenRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RefreshToken>> GetAllForUserAsync(Guid userId)
        {
            try
            {
                return await _context.RefreshTokens
                    .Where(x => x.UserId == userId)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null;
            }
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            try
            {
                return await _context.RefreshTokens
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Token == token);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null;
            }
        }

        public async Task RemoveExpiredAsync(DateTime now)
        {
            try
            {
                var expired = await _context.RefreshTokens
                    .Where(x => x.ExpiresAt <= now && x.IsRevoked)
                    .ToListAsync();

                if (!expired.Any()) return;

                _context.RefreshTokens.RemoveRange(expired);
                await SaveAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
            }
        }

        public async Task RevokeAsync(RefreshToken token, string? replacedBy = null, string? revokedByIp = null)
        {
            try
            {
                var existing = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == token.Id);
                if (existing == null) return;

                existing.IsRevoked = true;
                existing.RevokedAt = DateTime.UtcNow;
                existing.ReplacedByToken = replacedBy;
                existing.RevokedByIp = revokedByIp;

                _context.RefreshTokens.Update(existing);
                await SaveAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
            }
        }
    }
}
