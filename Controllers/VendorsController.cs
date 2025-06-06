using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models.DTO;
using Wedding_Planner.Services;

namespace Sample_MVC_ASP.Controllers
{
    public class VendorsController : Controller
    {
        private readonly IVendorsService _vendorsService;

        public VendorsController(IVendorsService vendorsService)
        {
            _vendorsService = vendorsService;
        }

        public IActionResult Vendors()
        {
            var vendors = _vendorsService.GetVendors();
            return View("Vendors", vendors);
        }

        //[HttpPost]
        //public IActionResult AddVendors(VendorsModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _vendorsService.AddVendor(model);
        //            return RedirectToAction("Vendors");
        //        }
        //        var vendors = _vendorsService.GetVendors();
        //        return View("Vendors", vendors);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        var vendors = _vendorsService.GetVendors();
        //        return View("Vendors", vendors);
        //    }
        //}


        [HttpPost]
        public IActionResult AddVendors(VendorsModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($"Error: {err.ErrorMessage}");
                    }
                }

                var vendors = _vendorsService.GetVendors();
                return View("Vendors", vendors);
            }

            _vendorsService.AddVendor(model);
            return RedirectToAction("Vendors");
        }

    }
}
