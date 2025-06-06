using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class CoupleRegisterModel
    {
        [Required]
        public string GroomName { get; set; }

        [Required]
        public string BrideName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? WeddingDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
