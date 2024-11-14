using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserService
    {
        Task<User?> CheckUserAsync(string uid);
    }
}
