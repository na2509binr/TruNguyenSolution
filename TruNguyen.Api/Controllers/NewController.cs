using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/new")]
    public class NewController : Controller
    {
        private readonly INewService _new;
        private readonly ILogger<NewController> _logger;
        public NewController(INewService _new_, ILogger<NewController> logger)
        {
            _new = _new_;
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
