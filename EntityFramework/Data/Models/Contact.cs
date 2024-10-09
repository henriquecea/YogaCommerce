using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCommerce.EntityFramework.Data.Models;

[Table("Contact")]
public class Contact : AuditableEntity
{
    [MaxLength(60)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(13)]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
