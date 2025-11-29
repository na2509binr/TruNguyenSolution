using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface ICategoryProductService
    {
        Task<List<CategoryProduct>> GetAll();
        Task<CategoryProduct> GetById(int id);
        Task<bool> Insert(CategoryProduct entity);
        Task<bool> Update(CategoryProduct entity);
        Task<bool> Delete(CategoryProduct entity);
    }
}
