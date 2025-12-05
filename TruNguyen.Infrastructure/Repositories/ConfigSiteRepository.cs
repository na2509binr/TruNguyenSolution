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
    public class ConfigSiteRepository : GenericRepository<ConfigSite, int>, IConfigSiteRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<ConfigSiteRepository> _logger;

        public ConfigSiteRepository(AppDbContext context, ILogger<ConfigSiteRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }

        public async Task<ConfigSite> GetIndex()
        {
            try
            {
                return await _context.ConfigSites.FirstOrDefaultAsync();
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
