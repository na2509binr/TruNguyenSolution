using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Application.Services;
using TruNguyen.Infrastructure.Interfaces;
using TruNguyen.Infrastructure.Repositories;

namespace TruNguyen.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddInfrastructure(configuration);

            services = TruNguyen.Infrastructure.DependencyInjection.AddInfrastructure(services, configuration);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryProductService, CategoryProductService>();
            services.AddScoped<IConfigSiteService, ConfigSiteService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<INewService, NewService>();
            services.AddScoped<INewsSectionService, NewsSectionService>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISeoMetaService, SeoMetaService>();
            // 🔹 Đăng ký các service tầng Application tại đây
            // Ví dụ:
            // services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IReportService, ReportService>();

            return services;
        }
    }
}
