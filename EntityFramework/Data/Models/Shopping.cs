using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCommerce.EntityFramework.Data.Models;

[Table("Shopping")]
public class Shopping : AuditableEntity
{
    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal ProductValue { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
}
