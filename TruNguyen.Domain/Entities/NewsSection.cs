using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class NewsSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        public New News { get; set; }

        public string Title { get; set; }           // Tiêu đề của phần (ví dụ: “Giới thiệu”)
        public string Content { get; set; }         // Nội dung chi tiết
        public int Order { get; set; }              // Thứ tự hiển thị
    }
}
