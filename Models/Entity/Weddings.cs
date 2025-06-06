using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class Weddings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CoupleId { get; set; }
        public int? PlannerId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal Budget { get; set; }

        public int GuestCount { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planning";

        [StringLength(100)]
        public string Theme { get; set; }

        public string Notes { get; set; }

        [Required]
        [Range(0, 100)]
        public int Progress { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CoupleId")]
        public virtual Couple Couple { get; set; }

        [ForeignKey("PlannerId")]
        public virtual WeddingPlanner Planner { get; set; }

        public virtual ICollection<WeddingChecklist> Checklists { get; set; }
        public virtual ICollection<WeddingTimeline> Timeline { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<WeddingVendor> WeddingVendors { get; set; }
    }
} 