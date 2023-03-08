using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Incident
    {
        public Guid IncidentId { get; set; }

        [MaxLength(40, ErrorMessage = "Incident name cannot be longer than 40 characters.")]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public ICollection<Account>? Accounts { get; set; }
    }
}
