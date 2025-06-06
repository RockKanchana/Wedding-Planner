using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models.DTO
{
    public class WeddingTimelineViewModel
    {
        public int Id { get; set; }

        [Required]
        public int WeddingId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Planned";
    }
}
