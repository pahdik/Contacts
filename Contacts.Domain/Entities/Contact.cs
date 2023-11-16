using Contacts.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Domain.Entities;

public class Contact : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string MobilePhone { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string JobTitle { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }
}
