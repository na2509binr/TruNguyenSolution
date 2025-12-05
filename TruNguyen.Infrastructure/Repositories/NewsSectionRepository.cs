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
    public class NewsSectionRepository : GenericRepository<NewsSection, int>, INewsSectionRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<NewsSectionRepository> _logger;

        public NewsSectionRepository(AppDbContext context, ILogger<NewsSectionRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }

        public async Task<List<NewsSection>> GetByNewIdAsync(int newsId)
        {
            try
            {
                return await _context.NewsSections.Where(x => x.NewsId == newsId).ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null;
            }
        }
    }
}
