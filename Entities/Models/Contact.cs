using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } //unique

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string? FirstName { get; set; }

        [MaxLength(40, ErrorMessage = "First name cannot be longer than 20 characters.")]
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        public Guid? AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
