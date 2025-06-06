using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        public int? WeddingId { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string MessageText { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;

        public DateTime? ReadDate { get; set; }

        // Navigation properties
        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual User Receiver { get; set; }

        [ForeignKey("WeddingId")]
        public virtual Weddings Wedding { get; set; }
    }
} 