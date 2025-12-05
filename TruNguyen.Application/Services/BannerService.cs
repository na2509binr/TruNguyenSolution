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
    public class BannerService : IBannerService
    {
        private readonly ILogger<BannerService> _logger;
        private readonly IBannerRepository _repo;

        public BannerService(ILogger<BannerService> logger, IBannerRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<Banner>> GetAll()
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

        public async Task<Banner> GetById(int id)
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

        public async Task<bool> Insert(Banner entity)
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

        public async Task<bool> Update(Banner entity)
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

        public async Task<bool> Delete(Banner entity)
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
