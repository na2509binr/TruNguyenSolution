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
    public class NewsSectionService : INewsSectionService
    {
        private readonly ILogger<NewsSectionService> _logger;
        private readonly INewsSectionRepository _newsSectionRepo;

        public NewsSectionService(ILogger<NewsSectionService> logger, INewsSectionRepository newsSectionRepo)
        {
            _logger = logger;
            _newsSectionRepo = newsSectionRepo;
        }

        public async Task<List<NewsSection>> GetAll()
        {
            try
            {
                return (await _newsSectionRepo.GetAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<List<NewsSection>> GetByNewId(int newsId)
        {
            try
            {
                return (await _newsSectionRepo.GetByNewIdAsync(newsId)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<NewsSection> GetById(int id)
        {
            try
            {
                return await _newsSectionRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(NewsSection entity)
        {
            try
            {
                await _newsSectionRepo.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(NewsSection entity)
        {
            try
            {
                await _newsSectionRepo.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(NewsSection entity)
        {
            try
            {
                await _newsSectionRepo.DeleteAsync(entity);
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
