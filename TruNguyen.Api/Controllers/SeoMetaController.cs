using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

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
