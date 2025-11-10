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
    public class PartnerService : IPartnerService
    {
        private readonly ILogger<PartnerService> _logger;
        private readonly IPartnerRepository _partnerRepo;

        public PartnerService(ILogger<PartnerService> logger, IPartnerRepository partnerRepo)
        {
            _logger = logger;
            _partnerRepo = partnerRepo;
        }

    }
}
