using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruNguyen.Domain.Entities
{
    public class SeoMeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Tiêu đề page (title tag)
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả ngắn (meta description)
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Từ khóa SEO (meta keywords)
        /// </summary>
        public string Keywords { get; set; } = string.Empty;

        /// <summary>
        /// URL canonical để tránh duplicate content
        /// </summary>
        public string CanonicalUrl { get; set; } = string.Empty;

        /// <summary>
        /// URL hình ảnh chính (dùng cho Open Graph / social sharing)
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Open Graph type (ví dụ: article, website)
        /// </summary>
        public string OgType { get; set; } = "website";

        /// <summary>
        /// Open Graph title
        /// </summary>
        public string OgTitle { get; set; } = string.Empty;

        /// <summary>
        /// Open Graph description
        /// </summary>
        public string OgDescription { get; set; } = string.Empty;

        /// <summary>
        /// Open Graph image
        /// </summary>
        public string OgImage { get; set; } = string.Empty;

        /// <summary>
        /// Twitter card type (summary, summary_large_image, etc)
        /// </summary>
        public string TwitterCard { get; set; } = "summary_large_image";

        /// <summary>
        /// Twitter title
        /// </summary>
        public string TwitterTitle { get; set; } = string.Empty;

        /// <summary>
        /// Twitter description
        /// </summary>
        public string TwitterDescription { get; set; } = string.Empty;

        /// <summary>
        /// Twitter image
        /// </summary>
        public string TwitterImage { get; set; } = string.Empty;

        /// <summary>
        /// Dữ liệu JSON-LD (schema.org)
        /// </summary>
        public string JsonLd { get; set; } = string.Empty;
    }

}
