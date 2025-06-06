using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class WeddingVendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WeddingId { get; set; }

        [Required]
        public int VendorId { get; set; }

        public int? ServiceId { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal? ContractAmount { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public string Notes { get; set; }

        // Navigation properties
        [ForeignKey("WeddingId")]
        public virtual Weddings Wedding { get; set; }

        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("ServiceId")]
        public virtual VendorService Service { get; set; }
    }
} 