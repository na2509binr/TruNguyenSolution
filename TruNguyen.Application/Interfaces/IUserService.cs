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
        Task<List<User>> GetAllUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);

    }
}
