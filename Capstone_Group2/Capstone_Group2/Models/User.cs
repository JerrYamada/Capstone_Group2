using System.ComponentModel.DataAnnotations;

namespace Capstone_Group2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
