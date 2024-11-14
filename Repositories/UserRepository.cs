using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBourbonCollective.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BourbonCollectiveDbContext dbContext;

        public UserRepository(BourbonCollectiveDbContext context)
        {
            dbContext = context;
        }

        // Check User
        public async Task<User?> CheckUserAsync(string uid)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.FirebaseId == uid);
        }

        // Register User
        public async Task<User> RegisterUserAsync(User newUser)
        {
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
