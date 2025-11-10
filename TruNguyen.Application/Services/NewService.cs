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
    public class NewService : INewService
    {
        private readonly ILogger<NewService> _logger;
        private readonly INewRepository _newRepo;

        public NewService(ILogger<NewService> logger, INewRepository newRepo)
        {
            _logger = logger;
            _newRepo = newRepo;
        }

    }
}
