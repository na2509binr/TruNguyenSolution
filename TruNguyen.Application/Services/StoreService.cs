using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly ILogger<StoreService> _logger;
        private readonly IStoreRepository _storeRepo;

        public StoreService(ILogger<StoreService> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }

        public async Task<List<Store>> GetAll()
        {
            try
            {
                return (await _storeRepo.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<Store> GetById(int id)
        {
            try
            {
                return await _storeRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(Store entity)
        {
            try
            {
                await _storeRepo.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(Store entity)
        {
            try
            {
                await _storeRepo.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(Store entity)
        {
            try
            {
                await _storeRepo.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return false;
            }
        }
    }
}
