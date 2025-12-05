using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruNguyen.Infrastructure.Interfaces;
using TruNguyen.Infrastructure.Repositories;

namespace TruNguyen.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("Connection string: " + connectionString);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // 🔹 Đăng ký Repository pattern nếu có //services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
            services.AddScoped<IConfigSiteRepository, ConfigSiteRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<INewRepository, NewRepository>();
            services.AddScoped<INewsSectionRepository, NewsSectionRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISeoMetaRepository, SeoMetaRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ICategoryNewRepository, CategoryNewRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            return services;
        }
    }
}
