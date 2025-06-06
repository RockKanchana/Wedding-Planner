using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models.DTO;
using Wedding_Planner.Services;

namespace Wedding_Planner.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // GET: /Guest/GuestManagement
        public IActionResult GuestManagement()
        {
            var weddingId = HttpContext.Session.GetInt32("WeddingId");
            if (weddingId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var guests = _guestService.GetGuestsByWeddingId(weddingId.Value);
            ViewBag.WeddingId = weddingId.Value;
            return View("GuestManagement", guests);
        }

        [HttpPost]
        public IActionResult AddGuest(GuestModel model)
        {
            var weddingId = HttpContext.Session.GetInt32("WeddingId");
            if (weddingId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            model.WeddingId = weddingId.Value;

            if (ModelState.IsValid)
            {
                _guestService.AddGuest(model);
                return RedirectToAction("GuestManagement");
            }

            var guests = _guestService.GetGuestsByWeddingId(model.WeddingId);
            ViewBag.WeddingId = model.WeddingId;
            return View("GuestManagement", guests);
        }

        //[HttpPost]
        //public IActionResult DeleteGuest(int id)
        //{
        //    var weddingId = HttpContext.Session.GetInt32("WeddingId");
        //    if (weddingId == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    _guestService.DeleteGuest(id);
        //    return RedirectToAction("GuestManagement");
        //}

        [HttpGet]
        public IActionResult UpdateGuest(int id)
        {
            var guest = _guestService.GetGuestById(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        [HttpPost]
        public IActionResult UpdateGuest(GuestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _guestService.UpdateGuest(model);
            return RedirectToAction("GuestManagement");
        }

        // POST: /Guest/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _guestService.DeleteGuest(id);
            return RedirectToAction("GuestManagement");
        }

    }

}
