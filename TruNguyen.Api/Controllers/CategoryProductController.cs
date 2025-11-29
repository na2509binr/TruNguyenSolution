using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/category-product")]
    public class CategoryProductController : Controller
    {
        private readonly ICategoryProductService _categoryProduct;
        private readonly ILogger<CategoryProductController> _logger;
        public CategoryProductController(ICategoryProductService categoryProduct, ILogger<CategoryProductController> logger)
        {
            _categoryProduct = categoryProduct;
            _logger = logger;
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _categoryProduct.GetAll();
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
        public async Task<IActionResult> Insert([FromBody] CategoryProduct entity)
        {
            try
            {
                var success = await _categoryProduct.Insert(entity);
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

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] CategoryProduct entity)
        {
            try
            {
                var success = await _categoryProduct.Update(entity);
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

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryProduct entity)
        {
            try
            {
                var success = await _categoryProduct.Delete(entity);
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
