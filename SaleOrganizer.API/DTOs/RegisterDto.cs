using System.ComponentModel.DataAnnotations;

namespace SaleOrganizer.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        //[RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])$", ErrorMessage = "Hasło musi zawierać dużą i małą literę oraz liczbę")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}