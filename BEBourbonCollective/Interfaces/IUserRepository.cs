using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> CheckUserAsync(string uid);

        Task <User> RegisterUserAsync(User newUser);

        Task <User?> GetSingleUserAsync(int id);

        Task <List<User>> GetAllUsersAsync();
        Task<User?> UpdateSingleUserAsync(int id, User updatedUser);

    }
}
