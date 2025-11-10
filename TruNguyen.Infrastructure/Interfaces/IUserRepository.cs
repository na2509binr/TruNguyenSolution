using TruNguyen.Domain.Entities;

namespace TruNguyen.Infrastructure.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        //Task AddAsync(User user);
        //Task UpdateAsync(User user);
    }
}
