using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class MemberController : Controller
    {
        private readonly IMemberService _member;
        private readonly ILogger<MemberController> _logger;
        public MemberController(IMemberService member, ILogger<MemberController> logger)
        {
            _member = member;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _member.GetAll();
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
        public async Task<IActionResult> Insert([FromBody] Member entity)
        {
            try
            {
                var success = await _member.Insert(entity);
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
        public async Task<IActionResult> Update([FromBody] Member entity)
        {
            try
            {
                var success = await _member.Update(entity);
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
        public async Task<IActionResult> Delete([FromBody] Member entity)
        {
            try
            {
                var success = await _member.Delete(entity);
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
