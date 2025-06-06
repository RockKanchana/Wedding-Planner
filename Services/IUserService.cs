using Wedding_Planner.Models.Entity;
using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services
{
    public interface IUserService
    {
        Task<bool> RegisterCoupleAsync(CoupleRegisterModel newCouple);

        Task<bool> RegisterWeddingPlannerAsync(WeddingPlannerRegisterModel newWeddingPlanner);

        Task<(bool isSuccess, User? user, string errorMessage)> LoginAsync(string email, string password);

        Task<User?> GetUserByIdAsync(int id);

        Task<bool> DeleteUserAsync(int id);

        //Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
