using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetFiltByCateId(int cateId);
        Task<Product> GetById(int id);
        Task<bool> Insert(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
    }
}
