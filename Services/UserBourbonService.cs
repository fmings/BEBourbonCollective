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
        public async Task<List<UserBourbon>> GetAllUserBourbons(int userId)
        {
            return await _userBourbonRepository.GetAllUserBourbons(userId); 
        }

    }
}
