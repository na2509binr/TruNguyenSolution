using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{
    public class BannerRepository : GenericRepository<Banner, int>, IBannerRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<BannerRepository> _logger;

        public BannerRepository(AppDbContext context, ILogger<BannerRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }
    }
}
