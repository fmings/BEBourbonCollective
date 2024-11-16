using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserBourbonService
    {
        Task <List<UserBourbon>> GetAllUserBourbonsAsync(int userId);
        Task<UserBourbon> AddUserBourbonAsync(UserBourbon newUserBourbon);
        Task<UserBourbon> UpdateUserBourbonAsync(int userBourbonId, UserBourbon updatedUserBourbon);
    }
}
