using System.Collections.Immutable;
using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBourbonCollective.Repositories
{
    public class UserBourbonRepository : IUserBourbonRepository
    {
        private readonly BourbonCollectiveDbContext dbContext;

        public UserBourbonRepository(BourbonCollectiveDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<UserBourbon>> GetAllUserBourbonsAsync(int userId)
        {
            List<UserBourbon> userBourbons = await dbContext.UserBourbons.Where(ub => ub.UserId == userId)
                .Include(ub => ub.User)
                .Include(ub => ub.Bourbon)
                    .ThenInclude(b => b.Distillery)
                .ToListAsync();

            return userBourbons;
        }

        public async Task<UserBourbon> AddUserBourbonAsync(UserBourbon newUserBourbon)
        {
            await dbContext.UserBourbons.AddAsync(newUserBourbon);
            await dbContext.SaveChangesAsync();
            return newUserBourbon;
        }

        public async Task<UserBourbon> UpdateUserBourbonAsync(int userBourbonId,  UserBourbon updatedUserBourbon)
        {
            var userBourbonToUpdate = await dbContext.UserBourbons.FirstOrDefaultAsync(ub => ub.Id == userBourbonId);

            if (userBourbonToUpdate == null)
            {
                return null;
            }

            userBourbonToUpdate.UserId = updatedUserBourbon.UserId;
            dbContext.SaveChangesAsync();
            return userBourbonToUpdate;
        }

    }
}
