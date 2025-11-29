using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);

    }
}
