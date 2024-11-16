using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserBourbonRepository
    {
        Task<List<UserBourbon>> GetAllUserBourbons(int userId);
    }
}
