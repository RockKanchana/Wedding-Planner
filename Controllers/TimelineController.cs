using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models.DTO;
using Wedding_Planner.Services;

namespace Wedding_Planner.Controllers
{
    public class TimelineController : Controller
    {
        private readonly ITimelineService _timelineService;

        public TimelineController(ITimelineService timelineService)
        {
            _timelineService = timelineService;
        }

        [HttpGet]
        public IActionResult Timeline()
        {
            int? weddingId = HttpContext.Session.GetInt32("WeddingId");
            if (weddingId == null)
                return RedirectToAction("Login", "Account");

            ViewBag.WeddingId = weddingId.Value;
            var data = _timelineService.GetTimelinesByWeddingId(weddingId.Value);
            return View(data);
        }

        [HttpPost]
        public IActionResult AddTimeline(WeddingTimelineViewModel model)
        {
            if (ModelState.IsValid)
            {
                _timelineService.AddTimeline(model);
                return RedirectToAction("Timeline");
            }

            return View("Timeline", _timelineService.GetTimelinesByWeddingId(model.WeddingId));
        }

        //[HttpPost]
        //public IActionResult UpdateTimeline(WeddingTimelineViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _timelineService.UpdateTimeline(model);
        //        return RedirectToAction("Timeline");
        //    }

        //    return View("Timeline", _timelineService.GetTimelinesByWeddingId(model.WeddingId));
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var timeline = _timelineService.GetTimelineById(id);
            if (timeline == null)
                return NotFound();

            return View("Edit", timeline);
        }

        [HttpPost]
        public IActionResult Edit(WeddingTimelineViewModel model)
        {
            if (ModelState.IsValid)
            {
                _timelineService.UpdateTimeline(model);
                return RedirectToAction("Timeline");
            }

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _timelineService.DeleteTimeline(id);
            return RedirectToAction("Timeline");
        }

    }
}
