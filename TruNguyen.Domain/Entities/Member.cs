using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }           // Tiêu đề của phần (ví dụ: “Giới thiệu”)
        public string Image { get; set; }         // Nội dung chi tiết
        public string Department { get; set; }         // Nội dung chi tiết
        public DateTime CreatedAt { get; set; }     // Ngày tạo
        public int Order { get; set; }              // Thứ tự hiển thị
        public bool IsActive { get; set; }           // Trạng thái kích hoạt
        public bool ShowWeb { get; set; }           // Trạng thái kích hoạt
    }
}
