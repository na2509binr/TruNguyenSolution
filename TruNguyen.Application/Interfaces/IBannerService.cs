using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IBannerService
    {
        Task<List<Banner>> GetAll();
        Task<Banner> GetById(int id);
        Task<bool> Insert(Banner entity);
        Task<bool> Update(Banner entity);
        Task<bool> Delete(Banner entity);
    }
}
