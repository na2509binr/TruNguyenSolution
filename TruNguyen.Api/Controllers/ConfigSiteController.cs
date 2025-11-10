using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/config-site")]
    public class ConfigSiteController : Controller
    {
        private readonly ICategoryProductService _configSite;
        private readonly ILogger<ConfigSiteController> _logger;
        public ConfigSiteController(ICategoryProductService configSite, ILogger<ConfigSiteController> logger)
        {
            _configSite = configSite;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok("success!");
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
