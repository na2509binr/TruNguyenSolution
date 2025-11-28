using Microsoft.EntityFrameworkCore;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CategoryProduct> CategoryProducts { get; set; } = null!;
        public DbSet<New> News { get; set; } = null!;
        public DbSet<NewsSection> NewsSections { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;
        public DbSet<SeoMeta> SeoMetas { get; set; } = null!;
        public DbSet<ConfigSite> ConfigSites { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    }
}
