using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {

    }
}
