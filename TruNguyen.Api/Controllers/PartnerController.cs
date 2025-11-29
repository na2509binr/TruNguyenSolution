using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/partner")]
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partner;
        private readonly ILogger<PartnerController> _logger;
        public PartnerController(IPartnerService partner, ILogger<PartnerController> logger)
        {
            _partner = partner;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _partner.GetAll();
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
        public async Task<IActionResult> Insert([FromBody] Partner partner)
        {
            try
            {
                var success = await _partner.Insert(partner);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(partner);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Partner partner)
        {
            try
            {
                var success = await _partner.Update(partner);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(partner);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Partner partner)
        {
            try
            {
                var success = await _partner.Delete(partner);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(partner);
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
