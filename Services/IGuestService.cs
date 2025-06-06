using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services
{
    public interface IGuestService
    {
        void AddGuest(GuestModel guest);
        List<GuestModel> GetGuestsByWeddingId(int weddingId);
        GuestModel GetGuestById(int id);
        void UpdateGuest(GuestModel guest);
        void DeleteGuest(int id);
    }
}
