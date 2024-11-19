using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Services
{
    public class UserBourbonService : IUserBourbonService
    {
        private readonly IUserBourbonRepository _userBourbonRepository;

        public UserBourbonService(IUserBourbonRepository userBourbonRepository)
        {
            _userBourbonRepository = userBourbonRepository;
        }
        public async Task<List<UserBourbon>> GetAllUserBourbonsAsync(int userId)
        {
            return await _userBourbonRepository.GetAllUserBourbonsAsync(userId); 
        }

        public async Task<UserBourbon> AddUserBourbonAsync(UserBourbon newUserBourbon)
        {
            return await _userBourbonRepository.AddUserBourbonAsync(newUserBourbon);
        }

        public async Task<UserBourbon> UpdateUserBourbonAsync(int userBourbonId, UserBourbon updatedUserBourbon)
        {
            return await _userBourbonRepository.UpdateUserBourbonAsync(userBourbonId, updatedUserBourbon);
        }

        public async Task<UserBourbon> DeleteUserBourbonAsync(int userBourbonId)
        {
            return await _userBourbonRepository.DeleteUserBourbonAsync(userBourbonId);
        }

    }
}
