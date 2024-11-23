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

         // Get Single User
         public async Task<User?> GetSingleUserAsync(int id)
        {
            return await dbContext.Users
                   .Include(u => u.UserBourbons)
                   .FirstOrDefaultAsync(u => u.Id == id);
        }

        // Get All Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await dbContext.Users
                .Include(u => u.UserBourbons)
                .ToListAsync();
        }

        // Update Single User
        public async Task<User?> UpdateSingleUserAsync(int id, User updatedUser)
        {
            var userToUpdate = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (userToUpdate == null) 
            {
                return null;
            }

            userToUpdate.Username = updatedUser.Username;
            userToUpdate.FullName = updatedUser.FullName;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.City = updatedUser.City;
            userToUpdate.State = updatedUser.State;

            await dbContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
