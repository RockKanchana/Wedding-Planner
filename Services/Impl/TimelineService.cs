using Wedding_Planner.Models.DTO;
using Wedding_Planner.Models.Entity;

namespace Wedding_Planner.Services.Impl
{
    public class TimelineService : ITimelineService
    {
        private readonly WeddingPlannerDbContext _context;

        public TimelineService(WeddingPlannerDbContext context)
        {
            _context = context;
        }

        public List<WeddingTimelineViewModel> GetTimelinesByWeddingId(int weddingId)
        {
            return _context.WeddingTimelines
                .Where(t => t.WeddingId == weddingId)
                .Select(t => new WeddingTimelineViewModel
                {
                    Id = t.Id,
                    WeddingId = t.WeddingId,
                    EventName = t.EventName,
                    Description = t.Description,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    Location = t.Location,
                    Status = t.Status
                })
                .ToList();
        }

        public void AddTimeline(WeddingTimelineViewModel model)
        {
            var entity = new WeddingTimeline
            {
                WeddingId = model.WeddingId,
                EventName = model.EventName,
                Description = model.Description,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Location = model.Location,
                Status = model.Status
            };
            _context.WeddingTimelines.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateTimeline(WeddingTimelineViewModel model)
        {
            var entity = _context.WeddingTimelines.FirstOrDefault(t => t.Id == model.Id);
            if (entity != null)
            {
                entity.EventName = model.EventName;
                entity.Description = model.Description;
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                entity.Location = model.Location;
                entity.Status = model.Status;

                _context.SaveChanges();
            }
        }

        public void DeleteTimeline(int id)
        {
            var timeline = _context.WeddingTimelines.FirstOrDefault(t => t.Id == id);
            if (timeline != null)
            {
                _context.WeddingTimelines.Remove(timeline);
                _context.SaveChanges();
            }
        }


        public WeddingTimelineViewModel GetTimelineById(int id)
        {
            var t = _context.WeddingTimelines.FirstOrDefault(x => x.Id == id);
            if (t == null) return null;

            return new WeddingTimelineViewModel
            {
                Id = t.Id,
                WeddingId = t.WeddingId,
                EventName = t.EventName,
                Description = t.Description,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                Location = t.Location,
                Status = t.Status
            };
        }
    }
}
