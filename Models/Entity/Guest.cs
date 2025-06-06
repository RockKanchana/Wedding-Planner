using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    [Table("Guest")]
    public class Guest
    {
        public int Id { get; set; }
        public int WeddingId { get; set; }

        [ForeignKey("WeddingId")]
        public Weddings Wedding { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public int TableNumber { get; set; }
    }
}
