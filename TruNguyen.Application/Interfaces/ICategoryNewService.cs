using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface ICategoryNewService
    {
        Task<List<CategoryNew>> GetAll();
        Task<CategoryNew> GetById(int id);
        Task<bool> Insert(CategoryNew entity);
        Task<bool> Update(CategoryNew entity);
        Task<bool> Delete(CategoryNew entity);
    }
}
