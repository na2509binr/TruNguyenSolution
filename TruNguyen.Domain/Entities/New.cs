using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class New
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public string Url { get; set; }
        public int View { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }


        // 👇 Thêm navigation property
        public ICollection<NewsSection> Sections { get; set; } = new List<NewsSection>();



        public New()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
