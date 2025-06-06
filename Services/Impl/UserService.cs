using Microsoft.AspNetCore.Identity;
using Wedding_Planner.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly WeddingPlannerDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(WeddingPlannerDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }


        //public async Task<bool> RegisterCoupleAsync(CoupleRegisterModel model)
        //{
        //    var user = new User
        //    {
        //        Username = model.Email,
        //        Status = 1,
        //        RoleId = 3
        //    };
        //    user.Password = _passwordHasher.HashPassword(user, model.Password);

        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();

        //    var couple = new Couple
        //    {
        //        UserId = user.Id,
        //        GroomName = model.GroomName,
        //        BrideName = model.BrideName,
        //        WeddingDate = model.WeddingDate,
        //        Email = model.Email,
        //        Contact = model.Contact,
        //        Address = model.Address
        //    };

        //    await _context.Couples.AddAsync(couple);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}


        public async Task<bool> RegisterCoupleAsync(CoupleRegisterModel model)
        {
            // Check if username/email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Email);
            if (existingUser != null)
            {
                // Return false or throw an exception to indicate duplication
                throw new Exception("This email is already registered.");
            }

            var user = new User
            {
                Username = model.Email,
                Status = 1,
                RoleId = 3
            };
            user.Password = _passwordHasher.HashPassword(user, model.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var couple = new Couple
            {
                UserId = user.Id,
                GroomName = model.GroomName,
                BrideName = model.BrideName,
                WeddingDate = model.WeddingDate,
                Email = model.Email,
                Contact = model.Contact,
                Address = model.Address
            };

            await _context.Couples.AddAsync(couple);
            await _context.SaveChangesAsync();

            // Create Wedding 
            var wedding = new Weddings
            {
                CoupleId = couple.Id,
                Name = $"{model.GroomName} & {model.BrideName}'s Wedding",
                Date = model.WeddingDate ?? DateTime.Now,
                Location = "To be decided",
                Budget = 0,
                GuestCount = 0,
                Theme = "",
                Notes = "",
                Progress = 0
            };

            await _context.Weddings.AddAsync(wedding);
            await _context.SaveChangesAsync();

            return true;
        }




        public async Task<bool> RegisterWeddingPlannerAsync(WeddingPlannerRegisterModel model)
        {
            // Check if username/email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Email);
            if (existingUser != null)
            {
                // Return false or throw an exception to indicate duplication
                throw new Exception("This email is already registered.");
            }

            var user = new User
            {
                Username = model.Email,
                Status = 1,
                RoleId = 2
            };
            user.Password = _passwordHasher.HashPassword(user, model.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var planner = new WeddingPlanner
            {
                UserID = user.Id,
                Name = model.Name,
                Email = model.Email,
                Contact = model.Contact,
                YearsOfExperience = model.YearsOfExperience,
                ServiceAreas = model.ServiceAreas,
                HourlyRate = model.HourlyRate
            };

            await _context.WeddingPlanners.AddAsync(planner);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<(bool isSuccess, User? user, string errorMessage)> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == email);
            if (user == null)
                return (false, null, "User not found");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
                return (true, user, "");

            return (false, null, "Invalid credentials");
        }


        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }


        //public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        //{
        //    if (!int.TryParse(userId, out int id)) return false;

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null) return false;

        //    var result = _passwordHasher.VerifyHashedPassword(user, user.Password, currentPassword);
        //    if (result != PasswordVerificationResult.Success) return false;

        //    user.Password = _passwordHasher.HashPassword(user, newPassword);
        //    _context.Users.Update(user);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == email);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Email);
            if (user == null) return false;

            user.Password = model.NewPassword;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}