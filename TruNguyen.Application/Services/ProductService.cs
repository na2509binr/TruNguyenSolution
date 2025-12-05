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
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepo;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                //var items = (await _productRepo.GetAllAsync()).ToList();

                var list = (await _productRepo.GetAllAsync()).ToList();

                foreach (var item in list)
                {
                    item.Url = ToSlug(item.Name);
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

        public async Task<List<Product>> GetFiltByCateId(int cateId)
        {
            try
            {
                var items = new List<Product>();
                if (cateId == -1)
                    items = (await _productRepo.GetAllAsync()).ToList();
                else
                    items = (await _productRepo.GetFiltByCateId(cateId)).ToList();



                return items;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var item = await _productRepo.GetByIdAsync(id);
                return item!;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(Product product)
        {
            try
            {
                product.Url = "/product/" + StringHelper.FormatUrlHepler(product.Name);
                await _productRepo.AddAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                product.Url = "/product/" + StringHelper.FormatUrlHepler(product.Name);
                await _productRepo.UpdateAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(Product product)
        {
            try
            {
                await _productRepo.DeleteAsync(product);
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




    public static class StringHelper
    {
        public static string FormatUrlHepler(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // 1. Chuyển về lowercase
            string normalized = input.ToLowerInvariant();

            // 2. Loại bỏ dấu tiếng Việt
            normalized = RemoveDiacritics(normalized);

            // 3. Thay tất cả ký tự không phải chữ số hoặc chữ cái thành khoảng trắng
            normalized = Regex.Replace(normalized, @"[^a-z0-9\s-]", " ");

            // 4. Thay nhiều khoảng trắng liên tiếp bằng 1 dấu "-"
            normalized = Regex.Replace(normalized, @"\s+", "-");

            // 5. Xóa các dấu "-" thừa đầu cuối
            normalized = normalized.Trim('-');

            return normalized;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    // Chuyển đ/Đ thành d
                    if (c == 'đ') stringBuilder.Append('d');
                    else if (c == 'Đ') stringBuilder.Append('d'); // lowercase luôn
                    else stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}




