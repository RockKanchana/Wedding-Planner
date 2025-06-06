using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class VendorServiceViewModel
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string PriceType { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MinimumOrder { get; set; }
    }

}
