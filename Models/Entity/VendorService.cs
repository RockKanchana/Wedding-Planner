using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class VendorService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string PriceType { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? MinimumOrder { get; set; }

        // Navigation properties
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<WeddingVendor> WeddingVendors { get; set; }
    }
} 