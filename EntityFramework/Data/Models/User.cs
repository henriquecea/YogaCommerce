using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCommerce.EntityFramework.Data.Models;

[Table("User")]
public class User : AuditableEntity
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Password { get; set; } = string.Empty;

    [Required]
    public bool TermsOfUseAccepted { get; set; }
}
