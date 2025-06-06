using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    [Table("WeddingPlanner")]
    public class WeddingPlanner
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? YearsOfExperience { get; set; }
        public string ServiceAreas { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? HourlyRate { get; set; }
        public string Contact { get; set; }

        public User User { get; set; }
    }
}
