using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menu;
        private readonly ILogger<MenuController> _logger;
        public MenuController(IMenuService menu, ILogger<MenuController> logger)
        {
            _menu = menu;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var menus = await _menu.GetAll();
                return Ok(menus);
                //return Ok("success!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
    }
}
