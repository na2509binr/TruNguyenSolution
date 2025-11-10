using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

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
