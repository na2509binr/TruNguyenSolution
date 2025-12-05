using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string? Url { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }

        // Quan hệ đệ quy
        [JsonIgnore]
        public Menu? Parent { get; set; }
        public ICollection<Menu>? Children { get; set; }

        // Nếu menu này trỏ đến một category nào đó
        public int? CategoryNewsId { get; set; }
        //public CategoryProduct? CategoryProducts { get; set; }

    }




}
