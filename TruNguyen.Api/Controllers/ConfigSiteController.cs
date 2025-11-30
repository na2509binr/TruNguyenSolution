using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/config-site")]
    public class ConfigSiteController : Controller
    {
        private readonly IConfigSiteService _configSite;
        private readonly ILogger<ConfigSiteController> _logger;
        public ConfigSiteController(IConfigSiteService configSite, ILogger<ConfigSiteController> logger)
        {
            _configSite = configSite;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _configSite.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] ConfigSite entity)
        {
            try
            {
                var success = await _configSite.Insert(entity);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ConfigSite entity)
        {
            try
            {
                var success = await _configSite.Update(entity);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] ConfigSite entity)
        {
            try
            {
                var success = await _configSite.Delete(entity);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
