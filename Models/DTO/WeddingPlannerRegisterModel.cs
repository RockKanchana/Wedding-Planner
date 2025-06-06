using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class WeddingPlannerRegisterModel
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public int? YearsOfExperience { get; set; }

        [Required]
        public string ServiceAreas { get; set; }

        [Required]
        public decimal? HourlyRate { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
