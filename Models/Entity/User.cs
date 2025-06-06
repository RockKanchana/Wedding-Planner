using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public Role Role { get; set; }
        public Admin Admin { get; set; }
        public WeddingPlanner WeddingPlanner { get; set; }
        public Couple Couple { get; set; }
    }
}
