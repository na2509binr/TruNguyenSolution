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
    public class CategoryNewService : ICategoryNewService
    {
        private readonly ILogger<CategoryNewService> _logger;
        private readonly ICategoryNewRepository _repo;

        public CategoryNewService(ILogger<CategoryNewService> logger, ICategoryNewRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<CategoryNew>> GetAll()
        {
            try
            {
                return (await _repo.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<CategoryNew> GetById(int id)
        {
            try
            {
                return await _repo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(CategoryNew entity)
        {
            try
            {
                await _repo.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(CategoryNew entity)
        {
            try
            {
                await _repo.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("L?i:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(CategoryNew entity)
        {
            try
            {
                await _repo.DeleteAsync(entity);
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
