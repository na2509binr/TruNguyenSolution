using Microsoft.Extensions.Logging;
using TruNguyen.Application.Interfaces;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Application.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ILogger<CategoryProductService> _logger;
        private readonly ICategoryProductRepository _categoryProductRepo;

        public CategoryProductService(ILogger<CategoryProductService> logger, ICategoryProductRepository categoryProductRepo)
        {
            _logger = logger;
            this._categoryProductRepo = categoryProductRepo;
        }


    }
}
