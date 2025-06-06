using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class VendorsModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }  // Add this

        [StringLength(100)]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public string Description { get; set; }

        [Display(Name = "Hourly Rate")]
        public decimal? HourlyRate { get; set; }

        public bool IsActive { get; set; } = true;

        public IEnumerable<SelectListItem> Categories { get; set; }  // Add this
    }


}
