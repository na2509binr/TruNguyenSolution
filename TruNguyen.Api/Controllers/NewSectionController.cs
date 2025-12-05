using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/news-section")]
    public class NewsSectionController : Controller
    {
        private readonly INewsSectionService _newsSection;
        private readonly ILogger<NewsSectionController> _logger;

        public NewsSectionController(INewsSectionService newsSection, ILogger<NewsSectionController> logger)
        {
            _newsSection = newsSection;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _newsSection.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("get-by-news-id")]
        public async Task<IActionResult> GetByNewId(int newsId)
        {
            try
            {
                var news = await _newsSection.GetByNewId(newsId);
                return Ok(news);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] NewsSection section)
        {
            try
            {
                var success = await _newsSection.Insert(section);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(section);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] NewsSection section)
        {
            try
            {
                var success = await _newsSection.Update(section);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(section);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[{MethodBase.GetCurrentMethod().Name}]");
                _logger.LogError("Lỗi:  " + ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] NewsSection section)
        {
            try
            {
                var success = await _newsSection.Delete(section);
                if (!success) return StatusCode(500, "Internal Server Error");
                return Ok(section);
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
