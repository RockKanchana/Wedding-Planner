using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string VendorName { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(100)]
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

        [Column(TypeName = "decimal(10,2)")]
        public decimal? HourlyRate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public virtual VendorCategory Category { get; set; }

        public virtual ICollection<VendorService> Services { get; set; }
        public virtual ICollection<VendorReview> Reviews { get; set; }
        public virtual ICollection<WeddingVendor> WeddingVendors { get; set; }
    }
} 