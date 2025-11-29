using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IConfigSiteService
    {
        Task<List<ConfigSite>> GetAll();
        Task<ConfigSite> GetById(int id);
        Task<bool> Insert(ConfigSite entity);
        Task<bool> Update(ConfigSite entity);
        Task<bool> Delete(ConfigSite entity);
    }
}
