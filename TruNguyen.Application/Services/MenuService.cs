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


                //var menus = (await _menuRepo.GetAllAsync()).ToList();
                //var treeMenus = _menuRepo.BuildTree(
                //    menus,
                //    null, 
                //    m => m.ParentId, 
                //    m => m.Id, 
                //    (m, children) => m.Children = children
                //);

                //return treeMenus;

                //return _menuRepo.BuildTree(
                //    (await _menuRepo.GetAllAsync()).ToList(),
                //    null,
                //    m => m.ParentId,
                //    m => m.Id,
                //    (m, children) => m.Children = children
                //);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return null!;
            }
        }
    }
}
