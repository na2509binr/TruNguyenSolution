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
    public class ConfigSiteService : IConfigSiteService
    {
        private readonly ILogger<ConfigSiteService> _logger;
        private readonly IConfigSiteRepository _configSiteRepo;
        public ConfigSiteService(ILogger<ConfigSiteService> logger, IConfigSiteRepository configSiteRepo)
        {
            _logger = logger;
            _configSiteRepo = configSiteRepo;
        }

        public async Task<List<ConfigSite>> GetAll()
        {
            try
            {
                return (await _configSiteRepo.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<ConfigSite> GetById(int id)
        {
            try
            {
                return await _configSiteRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(ConfigSite entity)
        {
            try
            {
                await _configSiteRepo.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(ConfigSite entity)
        {
            try
            {
                await _configSiteRepo.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(ConfigSite entity)
        {
            try
            {
                await _configSiteRepo.DeleteAsync(entity);
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
