using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Application.Interfaces;
using TruNguyen.Infrastructure.Interfaces;
using TruNguyen.Infrastructure.Repositories;

namespace TruNguyen.Application.Services
{
    public class NewsSectionService : INewsSectionService
    {
        private readonly ILogger<NewsSectionService> _logger;
        private readonly INewsSectionRepository _newsSectionRepo;

        public NewsSectionService(ILogger<NewsSectionService> logger, INewsSectionRepository newsSectionRepo)
        {
            _logger = logger;
            _newsSectionRepo = newsSectionRepo;
        }

    }
}
