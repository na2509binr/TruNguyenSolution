using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TruNguyen.Application.Interfaces;

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
