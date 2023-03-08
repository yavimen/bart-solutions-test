using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Account name cannot be longer than 20 characters.")]
        public string? Name { get; set; } //unique

        public ICollection<Contact>? Contacts { get; set; }

        public Guid? IncidentId { get; set;}
        public Incident? Incident { get; set;}
    }
}
