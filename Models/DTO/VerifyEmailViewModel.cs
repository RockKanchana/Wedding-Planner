using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class VerifyEmailViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
