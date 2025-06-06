using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class VendorCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }

}
