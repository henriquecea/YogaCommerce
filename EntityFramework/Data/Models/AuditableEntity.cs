using System.ComponentModel.DataAnnotations;

namespace YogaCommerce.EntityFramework.Data.Models
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedTime { get; set; }
    }
}
