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
    public class PartnerService : IPartnerService
    {
        private readonly ILogger<PartnerService> _logger;
        private readonly IPartnerRepository _partnerRepo;

        public PartnerService(ILogger<PartnerService> logger, IPartnerRepository partnerRepo)
        {
            _logger = logger;
            _partnerRepo = partnerRepo;
        }

        public async Task<List<Partner>> GetAll()
        {
            try
            {
                var items = (await _partnerRepo.GetAllAsync()).ToList();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<Partner> GetById(int id)
        {
            try
            {
                var item = await _partnerRepo.GetByIdAsync(id);
                return item!;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(Partner partner)
        {
            try
            {
                await _partnerRepo.AddAsync(partner);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(Partner partner)
        {
            try
            {
                await _partnerRepo.UpdateAsync(partner);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(Partner partner)
        {
            try
            {
                await _partnerRepo.DeleteAsync(partner);
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
