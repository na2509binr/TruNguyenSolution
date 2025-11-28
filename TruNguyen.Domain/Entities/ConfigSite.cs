using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class ConfigSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Thông tin chung

        //public string Title { get; set; }
        public string Email { get; set; }
        public string Hotline { get; set; }
        public string Description { get; set; }
        public string InfoContact { get; set; }
        public string InfoFooter { get; set; }
        public string Image { get; set; }
        public string Favicon { get; set; }
        public string GoogleMap { get; set; }
        public string GoogleAnalytics { get; set; }
        public string Place { get; set; }
        public string AboutImage { get; set; }
        public string AboutText { get; set; }
        public string AboutUrl { get; set; }



        //Mạng xã hội
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Tiktok { get; set; }
        public string Twitter { get; set; }
        public string X { get; set; }
        public string Youtube { get; set; }
        public string Pinterest { get; set; }
        public string LiveChat { get; set; }
    }
}
