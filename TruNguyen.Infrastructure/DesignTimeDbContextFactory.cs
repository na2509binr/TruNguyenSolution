using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TruNguyen.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // ✅ Lấy ENV đang chạy (Development, Production...)
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                              ?? "Development";

            // ✅ Tìm folder API để load appsettings.
            var basePath = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(basePath, "..", "TruNguyen.Api");

            // Load configuration từ appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();


            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);


            //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            //// ✅ Nhúng cứng connection string để chạy migration (thiết kế chuẩn Onion)
            //optionsBuilder.UseSqlServer("Server=localhost;Database=TruNguyen;User Id=sa;Password=sa;TrustServerCertificate=True;");

            //return new AppDbContext(optionsBuilder.Options);
        }
    }
}
