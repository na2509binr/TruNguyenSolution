using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<bool> Insert(Member entity);
        Task<bool> Update(Member entity);
        Task<bool> Delete(Member entity);
    }
}
