using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    [Table("WeddingTimeline")]
    public class WeddingTimeline
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WeddingId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planned";

        // Navigation properties
        [ForeignKey("WeddingId")]
        public virtual Weddings Wedding { get; set; }
    }
} 