using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/seo-meta")]
    public class SeoMetaController : Controller
    {
        private readonly ISeoMetaService _seoMeta;
        private readonly ILogger<SeoMetaController> _logger;
        public SeoMetaController(ISeoMetaService seoMeta, ILogger<SeoMetaController> logger)
        {
            _seoMeta = seoMeta;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _seoMeta.GetAll();
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
        public async Task<IActionResult> Insert([FromBody] SeoMeta entity)
        {
            try
            {
                var success = await _seoMeta.Insert(entity);
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
        public async Task<IActionResult> Update([FromBody] SeoMeta entity)
        {
            try
            {
                var success = await _seoMeta.Update(entity);
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
        public async Task<IActionResult> Delete([FromBody] SeoMeta entity)
        {
            try
            {
                var success = await _seoMeta.Delete(entity);
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
