using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{
    public class CategoryNewRepository : GenericRepository<CategoryNew, int>, ICategoryNewRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryNewRepository> _logger;

        public CategoryNewRepository(AppDbContext context, ILogger<CategoryNewRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }
    }
}
