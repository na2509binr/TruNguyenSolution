using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAll();
        Task<Store> GetById(int id);
        Task<bool> Insert(Store entity);
        Task<bool> Update(Store entity);
        Task<bool> Delete(Store entity);
    }
}
