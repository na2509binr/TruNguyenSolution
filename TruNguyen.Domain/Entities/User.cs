using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!; // hashed password
        public string? DisplayName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsLocked { get; set; } = false;

        public UserRole Role { get; set; } = UserRole.User;
    }


    public enum UserRole
    {
        Dev,
        Admin,
        User
    }
}
