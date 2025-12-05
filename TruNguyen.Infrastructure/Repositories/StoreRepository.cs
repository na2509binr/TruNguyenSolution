using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{
    public class StoreRepository : GenericRepository<Store, int>, IStoreRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<StoreRepository> _logger;

        public StoreRepository(AppDbContext context, ILogger<StoreRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }
    }
}
