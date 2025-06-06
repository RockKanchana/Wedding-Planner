using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class WeddingChecklist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WeddingId { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(20)]
        public string Priority { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Not Started";

        public int? AssignedTo { get; set; }

        public DateTime? CompletedDate { get; set; }

        // Navigation properties
        [ForeignKey("WeddingId")]
        public virtual Weddings Wedding { get; set; }

        [ForeignKey("AssignedTo")]
        public virtual User AssignedUser { get; set; }
    }
} 