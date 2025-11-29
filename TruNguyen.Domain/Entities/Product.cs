using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string? Url { get; set; }
        public int? CateId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsActive;

        //[ForeignKey(nameof(CategoryProductId))]
        public int CategoryProductId { get; set; }
        //public CategoryProduct CategoryProducts { get; set; }
    }

}
