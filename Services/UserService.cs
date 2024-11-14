using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> CheckUserAsync(string uid)
        {
            return await _userRepository.CheckUserAsync(uid);
        }

        public async Task<User> RegisterUserAsync(User newUser)
        {
            return await _userRepository.RegisterUserAsync(newUser);
        }
    }
}
