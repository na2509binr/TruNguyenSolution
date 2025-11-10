using Microsoft.Extensions.Logging;
using TruNguyen.Application.Interfaces;
using TruNguyen.Infrastructure.Interfaces;
using TruNguyen.Infrastructure.Repositories;

namespace TruNguyen.Application.Services
{
    public class SeoMetaService : ISeoMetaService
    {
        private readonly ILogger<SeoMetaService> _logger;
        private readonly ISeoMetaRepository _productRepo;

        public SeoMetaService(ILogger<SeoMetaService> logger, ISeoMetaRepository productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }
    }
}
