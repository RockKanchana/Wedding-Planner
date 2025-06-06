using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }

        public int? WeddingId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EstimatedAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ActualAmount { get; set; }

        // Navigation properties
        [ForeignKey("WeddingId")]
        public virtual Weddings Wedding { get; set; }
    }
} 