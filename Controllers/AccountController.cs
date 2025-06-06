using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models.DTO;
using Wedding_Planner.Models.Entity;
using Wedding_Planner.Services;

namespace Wedding_Planner.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly WeddingPlannerDbContext _context;

        public AccountController(IUserService userService, WeddingPlannerDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        //GET: Register View
        [HttpGet]
        public IActionResult RegisterCouple()
        {
            return View();
        }

        // GET: Register View
        [HttpGet]
        public IActionResult RegisterPlanner()
        {
            return View();
        }

        // GET: Login View
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // GET: Logout View
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCouple(CoupleRegisterModel newCouple)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isRegistered = await _userService.RegisterCoupleAsync(newCouple);
                    if (isRegistered)
                    {
                        TempData["SuccessMessage"] = "Account Created Successfully!";
                        return RedirectToAction("Login");
                    }
                }
                return View(newCouple);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(newCouple);
            }
        }



        // POST: Register Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPlanner(WeddingPlannerRegisterModel newPlanner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isRegistered = await _userService.RegisterWeddingPlannerAsync(newPlanner);
                    if (isRegistered)
                    {
                        TempData["SuccessMessage"] = "Account Created Successfully!";
                        return RedirectToAction("Login");
                    }
                }
                return View(newPlanner);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(newPlanner);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var (isSuccess, user, errorMessage) = await _userService.LoginAsync(email, password);

                if (isSuccess && user != null)
                {
                    // Get Role name
                    var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
                    string roleName = role?.Name ?? "Unknown";

                    // Store basic session data
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("UserID", user.Id.ToString());
                    HttpContext.Session.SetString("Role", roleName);

                    // If the role is Couple, store WeddingId
                    if (roleName == "Couple")
                    {
                        var couple = await _context.Couples.FirstOrDefaultAsync(c => c.UserId == user.Id);
                        if (couple != null)
                        {
                            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.CoupleId == couple.Id);
                            if (wedding != null)
                            {
                                HttpContext.Session.SetInt32("WeddingId", wedding.Id);
                            }
                        }
                    }

                    // Redirect based on role
                    return roleName switch
                    {
                        "Admin" => RedirectToAction("AdminDashboard", "Home"),
                        "Planner" => RedirectToAction("PlannerDashboard", "Home"),
                        "Couple" => RedirectToAction("CoupleDashboard", "Home"),
                        _ => RedirectToAction("Index", "Home")
                    };
                }

                ViewBag.Error = errorMessage;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred during login. Please try again later. Error: {ex.Message}";
                return View("Error");
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var user = await _userService.GetUserByIdAsync(id.Value);

                if (user == null)
                {
                    return NotFound();
                }
                return Json(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while retrieving the user. Please try again later: {ex.Message}";
                return View("Error");
            }
        }


        // POST: User Delete By ID
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _userService.DeleteUserAsync(id);
                return Json(new { success });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the user. Please try again later: {ex.Message}";
                return View("Error");
            }
        }


        //// POST : Change Password Method
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        //{
        //    try
        //    {
        //        var userId = HttpContext.Session.GetString("UserID");
        //        if (userId == null)
        //        {
        //            return RedirectToAction("Login", "Account");
        //        }
        //        var success = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);
        //        if (!success)
        //        {
        //            TempData["ErrorMessage"] = "Current password is incorrect.";
        //            return RedirectToAction("Setting");
        //        }
        //        TempData["SuccessMessage"] = "Password updated successfully!";
        //        return RedirectToAction("Setting");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = $"An error occurred while changing the user password. Please try again later: {ex.Message}";
        //        return View("Error");
        //    }
        //}

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Email not found. Please try again.";
                return RedirectToAction("VerifyEmail");
            }

            return RedirectToAction("ResetPassword", new { id = user.Id });
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.ResetPasswordAsync(model);
            if (result)
            {
                TempData["SuccessMessage"] = "Password reset successfully.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Failed to reset password.");
            return View(model);
        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    RoleName = u.Role != null ? u.Role.Name : "N/A",
                    Status = u.Status
                })
                .ToListAsync();

            return View(users);
        }



    }
}
