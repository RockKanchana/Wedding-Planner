using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PlannerDashboard()
        {
            // Example dummy data — you can replace this with real data from _context
            ViewBag.ActiveWeddings = 5;
            ViewBag.UpcomingTasks = 3;
            ViewBag.TotalBudget = 15000;
            ViewBag.VendorContracts = 4;

            ViewBag.MyWeddings = new List<dynamic>
        {
            new { CoupleName = "John & Jane", Date = DateTime.Today, Venue = "Palm Garden", Status = "Active" },
            new { CoupleName = "Mark & Lisa", Date = DateTime.Today.AddDays(30), Venue = "Ocean View", Status = "Pending" }
        };

            ViewBag.UpcomingTasksList = new List<dynamic>
        {
            new { Name = "Cake Tasting", WeddingName = "John & Jane", DueDate = DateTime.Today.AddDays(2), Status = "Pending" },
            new { Name = "Rehearsal", WeddingName = "Mark & Lisa", DueDate = DateTime.Today.AddDays(5), Status = "Completed" }
        };

            return View();
        }


        [HttpGet]
        public IActionResult AdminDashboard()
        {
            // Dummy stats
            ViewBag.TotalUsers = 25;
            ViewBag.ActiveWeddings = 6;
            ViewBag.TotalVendors = 12;
            ViewBag.TotalPlanners = 4;

            // Dummy recent users
            ViewBag.RecentUsers = new List<dynamic>
    {
        new { Username = "chamath123", Role = "Planner", Email = "chamath@example.com" },
        new { Username = "nilu456", Role = "Couple", Email = "nilu@example.com" },
        new { Username = "admin007", Role = "Admin", Email = "admin@example.com" },
        new { Username = "planny98", Role = "Planner", Email = "plan@example.com" },
        new { Username = "sandy21", Role = "Couple", Email = "sandy@example.com" }
    };

            // Dummy recent weddings
            ViewBag.RecentWeddings = new List<dynamic>
    {
        new { CoupleName = "John & Nilu", Date = DateTime.Now.AddDays(10), Venue = "Colombo" },
        new { CoupleName = "Sahan & Dilmi", Date = DateTime.Now.AddDays(20), Venue = "Kandy" },
        new { CoupleName = "Kasun & Anu", Date = DateTime.Now.AddDays(5), Venue = "Galle" },
        new { CoupleName = "Ruwan & Samanthi", Date = DateTime.Now.AddDays(30), Venue = "Negombo" },
        new { CoupleName = "Nadeesha & Thisara", Date = DateTime.Now.AddDays(15), Venue = "Matara" }
    };

            return View();
        }


        [HttpGet]
        public IActionResult CoupleDashboard()
        {
            // Basic info
            ViewBag.CoupleName = "John & Ann";
            ViewBag.WeddingDate = DateTime.Now.AddDays(30); // Wedding in 30 days
            ViewBag.Venue = "Kingsbury Hotel, Colombo";
            ViewBag.Theme = "Rustic Garden";
            ViewBag.WeddingPlanner = "Elegant Events (Planner123)";

            // Dashboard Metrics
            ViewBag.DaysUntilWedding = (ViewBag.WeddingDate - DateTime.Now).Days;
            ViewBag.BudgetUsed = 65; // 65%
            ViewBag.GuestCount = 3;
            ViewBag.TasksCompleted = 50; // 70%
            ViewBag.VendorProgress = 80; // 80%

            // Upcoming Tasks
            ViewBag.UpcomingTasks = new List<dynamic>
    {
        new { Name = "Finalize guest list", DueDate = DateTime.Now.AddDays(3), Status = "Pending" },
        new { Name = "Book photographer", DueDate = DateTime.Now.AddDays(5), Status = "Completed" },
        new { Name = "Venue decoration plan", DueDate = DateTime.Now.AddDays(7), Status = "Pending" }
    };

            // Vendors
            ViewBag.Vendors = new List<dynamic>
    {
        new { Name = "Lush Decor", Service = "Decoration", Status = "Confirmed", HasContract = true },
        new { Name = "Shutter Studio", Service = "Photography", Status = "Pending", HasContract = false },
        new { Name = "Sweet Treats", Service = "Catering", Status = "Confirmed", HasContract = true }
    };

            return View();
        }

        [HttpGet]
        public IActionResult MyClients()
        {
            // Dummy accepted clients and weddings
            ViewBag.AcceptedClients = new List<dynamic>
            {
                new { CoupleName = "John & Jane", WeddingDate = DateTime.Today.AddDays(30), Venue = "Palm Garden", Status = "Active" },
                new { CoupleName = "Mark & Lisa", WeddingDate = DateTime.Today.AddDays(60), Venue = "Ocean View", Status = "Confirmed" }
            };

            // Dummy couple requests
            ViewBag.CoupleRequests = new List<dynamic>
            {
                new { RequestId = 1, CoupleName = "Alex & Mia", WeddingDate = DateTime.Today.AddDays(90), Venue = "Sunset Hall", Status = "Pending" },
                new { RequestId = 2, CoupleName = "Sam & Emma", WeddingDate = DateTime.Today.AddDays(120), Venue = "Royal Banquet", Status = "Pending" }
            };

            // Dummy wedding details for modal
            ViewBag.WeddingDetails = new Dictionary<int, dynamic>
            {
                { 1, new { CoupleName = "Alex & Mia", WeddingDate = DateTime.Today.AddDays(90), Venue = "Sunset Hall", Theme = "Classic", Guests = 150, Budget = "$10,000" } },
                { 2, new { CoupleName = "Sam & Emma", WeddingDate = DateTime.Today.AddDays(120), Venue = "Royal Banquet", Theme = "Modern", Guests = 200, Budget = "$15,000" } }
            };

            return View("MyClients");
        }

        [HttpGet]
        public IActionResult PlannerVendors()
        {
            return View("../Vender/PlannerVendors");
        }

        [HttpGet]
        public IActionResult AdminReports()
        {
            return View("AdminReports");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
