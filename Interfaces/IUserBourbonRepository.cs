using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserBourbonRepository
    {
        Task<List<UserBourbon>> GetAllUserBourbonsAsync(int userId);
        Task<UserBourbon> AddUserBourbonAsync(UserBourbon newUserBourbon);
        Task<UserBourbon> UpdateUserBourbonAsync(int userBourbonId, UserBourbon updatedUserBourbon);
        Task<UserBourbon> DeleteUserBourbonAsync(int userBourbonId);
    }
}
