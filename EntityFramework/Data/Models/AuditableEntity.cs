using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCommerce.EntityFramework.Data.Models
{
    public abstract class AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedTime { get; set; }
    }
}
