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
    public class MenuService : IMenuService
    {
        private readonly ILogger<MenuService> _logger;
        private readonly IMenuRepository _menuRepo;

        public MenuService(ILogger<MenuService> logger, IMenuRepository menuRepo)
        {
            _logger = logger;
            _menuRepo = menuRepo;
        }

        public async Task<List<Menu>> GetAll()
        {
            try
            {
                var menus = (await _menuRepo.GetAllAsync()).ToList();

                return menus;

                //var treeMenus = _menuRepo.BuildTree(
                //    menus,
                //    null,
                //    m => m.ParentId,
                //    m => m.Id,
                //    (m, children) => m.Children = children
                //);

                //return treeMenus;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<List<Menu>> GetTree()
        {
            try
            {
                var menus = (await _menuRepo.GetAllAsync()).ToList();

                var treeMenus = _menuRepo.BuildTree(
                    menus,
                    null,
                    m => m.ParentId,
                    m => m.Id,
                    (m, children) => m.Children = children
                );

                return treeMenus;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<Menu> GetById(int id)
        {
            try
            {
                return await _menuRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }

        public async Task<bool> Insert(Menu menu)
        {
            try
            {
                await _menuRepo.AddAsync(menu);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Update(Menu menu)
        {
            try
            {
                await _menuRepo.UpdateAsync(menu);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(Menu menu)
        {
            try
            {
                await _menuRepo.DeleteAsync(menu);
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
