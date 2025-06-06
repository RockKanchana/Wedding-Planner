using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services
{
    public interface ITimelineService
    {
        List<WeddingTimelineViewModel> GetTimelinesByWeddingId(int weddingId);
        void AddTimeline(WeddingTimelineViewModel model);
        void UpdateTimeline(WeddingTimelineViewModel model);
        void DeleteTimeline(int id);
        WeddingTimelineViewModel GetTimelineById(int id);
    }
}
