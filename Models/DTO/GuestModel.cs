namespace Wedding_Planner.Models.DTO
{
    public class GuestModel
    {
        public int Id { get; set; }

        public int WeddingId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int TableNumber { get; set; }
    }
}
