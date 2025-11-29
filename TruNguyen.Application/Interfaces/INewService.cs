using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface INewService
    {
        Task<List<New>> GetAll();
        Task<New> GetById(int id);
        Task<bool> Insert(New entity);
        Task<bool> Update(New entity);
        Task<bool> Delete(New entity);
    }
}
