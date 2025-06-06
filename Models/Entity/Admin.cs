namespace Wedding_Planner.Models.Entity
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User User { get; set; }
    }
}
