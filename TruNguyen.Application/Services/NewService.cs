using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                //return (await _newRepo.GetAllAsync()).ToList();

                var list = (await _newRepo.GetAllAsync()).ToList();

                foreach (var item in list)
                {
                    item.Url = ToSlug(item.Title);
                }

                return list;
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



        public static string ToSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) return "";

            // Thay đ/Đ trước
            string str = phrase.Replace("Đ", "D").Replace("đ", "d");

            // Chuẩn hoá Unicode về dạng tách dấu
            str = str.Normalize(NormalizationForm.FormD);

            // Loại bỏ dấu
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            str = sb.ToString();

            // Lowercase
            str = str.ToLowerInvariant();

            // Loại ký tự không hợp lệ
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // Trim, đổi khoảng trắng thành -, gom nhiều - thành 1
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"-+", "-");

            return str;
        }
    }
}
