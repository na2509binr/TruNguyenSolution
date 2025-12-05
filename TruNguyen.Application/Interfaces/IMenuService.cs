using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAll();
        Task<List<Menu>> GetTree();
        Task<Menu> GetById(int id);
        Task<bool> Insert(Menu menu);
        Task<bool> Update(Menu menu);
        Task<bool> Delete(Menu menu);
    }
}
