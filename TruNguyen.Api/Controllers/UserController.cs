using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _user;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService user, ILogger<UserController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _user.GetAll();
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
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            try
            {
                var bl = await _user.Insert(user);
                if (!bl) return StatusCode(500, "Internal Server Error");

                return Ok("Xảy ra lỗi trong quá trình Thêm mới!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                var bl = await _user.Update(user);
                if (!bl) return StatusCode(500, "Internal Server Error");

                return Ok("Xảy ra lỗi trong quá trình Cập nhật!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = await _user.GetById(id);
                if (user == null ) return StatusCode(500, "Internal Server Error");


                var bl = await _user.Delete(user);
                if (!bl) return StatusCode(500, "Internal Server Error");

                return Ok("Xảy ra lỗi trong quá trình Xóa!");
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
