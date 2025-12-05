using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruNguyen.Domain.Entities
{
    public class Banner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        //[MaxLength(500)]
        //public string? Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string ImageUrl { get; set; } = string.Empty;

        //[MaxLength(250)]
        //public string? RedirectUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public int DisplayOrder { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
