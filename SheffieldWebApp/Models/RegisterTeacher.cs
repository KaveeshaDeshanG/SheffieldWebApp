using System.ComponentModel.DataAnnotations;

namespace SheffieldWebApp.Models
{
    public class RegisterTeacher
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string Qualification { get; set; }
        [Required]
        public int Age { get; set; }
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
