using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserBourbonService
    {
        Task <List<UserBourbon>> GetAllUserBourbons(int userId);
    }
}
