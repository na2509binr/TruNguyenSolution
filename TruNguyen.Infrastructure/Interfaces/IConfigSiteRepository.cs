using TruNguyen.Domain.Entities;

namespace TruNguyen.Infrastructure.Interfaces
{
    public interface IConfigSiteRepository : IGenericRepository<ConfigSite, int>
    {
        Task<ConfigSite> GetIndex();
    }
}
