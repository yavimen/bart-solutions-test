using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    public class IncidentForCreationDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Account name cannot be longer than 20 characters.")]
        [MinLength(3, ErrorMessage = "Account name cannot be less than 3 characters.")]
        public string? AccountName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set;}

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(40, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        public string? LastName { get; set; }

        [Required]
        public string? IncidentDescription { get; set;}
    }
}
