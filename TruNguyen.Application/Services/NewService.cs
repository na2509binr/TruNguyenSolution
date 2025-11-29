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
    public class NewService : INewService
    {
        private readonly ILogger<NewService> _logger;
        private readonly INewRepository _newRepo;

        public NewService(ILogger<NewService> logger, INewRepository newRepo)
        {
            _logger = logger;
            _newRepo = newRepo;
        }

        public async Task<List<New>> GetAll()
        {
            try
            {
                return (await _newRepo.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<New> GetById(int id)
        {
            try
            {
                return await _newRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(New entity)
        {
            try
            {
                await _newRepo.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(New entity)
        {
            try
            {
                await _newRepo.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(New entity)
        {
            try
            {
                await _newRepo.DeleteAsync(entity);
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
