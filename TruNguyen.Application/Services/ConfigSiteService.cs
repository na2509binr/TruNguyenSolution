using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Application.Interfaces;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Application.Services
{
    public class ConfigSiteService : IConfigSiteService
    {
        private readonly ILogger<ConfigSiteService> _logger;
        private readonly IConfigSiteRepository _configSiteRepo;
        public ConfigSiteService(ILogger<ConfigSiteService> logger, IConfigSiteRepository configSiteRepo)
        {
            _logger = logger;
            _configSiteRepo = configSiteRepo;
        }
    }
}
