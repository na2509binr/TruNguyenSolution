using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IPartnerService
    {
        Task<List<Partner>> GetAll();
        Task<Partner> GetById(int id);
        Task<bool> Insert(Partner partner);
        Task<bool> Update(Partner partner);
        Task<bool> Delete(Partner partner);
    }
}
