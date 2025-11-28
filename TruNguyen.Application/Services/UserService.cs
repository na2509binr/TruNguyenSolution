using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepo;

        public UserService(ILogger<UserService> logger, IUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }


        public async Task<List<User>> GetAllUser(User user)
        {
            try
            {
                var users = (await _userRepo.GetAllAsync()).ToList();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var userById = await _userRepo.GetByIdAsync(id);
                return userById;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> InsertUser(User user)
        {
            try
            {
                await _userRepo.AddAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                await _userRepo.UpdateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                await _userRepo.DeleteAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }
    }
}
