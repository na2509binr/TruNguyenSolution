using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu, int>, IMenuRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly AppDbContext _context;
        private readonly ILogger<MenuRepository> _logger;

        public MenuRepository(AppDbContext context, ILogger<MenuRepository> logger, DbContextOptions<AppDbContext> options) : base(context)
        {
            _options = options;
            _context = context;
            _logger = logger;
        }
    }
}
