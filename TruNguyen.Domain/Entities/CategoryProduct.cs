using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class CategoryProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
        public bool ShowMenu { get; set; }



        //// Đệ quy
        //public CategoryProduct? Parent { get; set; }
        //public ICollection<CategoryProduct>? Children { get; set; }

        //// Liên kết sản phẩm
        //public ICollection<Product>? Products { get; set; }



    }

}
