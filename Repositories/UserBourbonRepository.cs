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

        public async Task<List<UserBourbon>> GetAllUserBourbons(int userId)
        {
            List<UserBourbon> userBourbons = await dbContext.UserBourbons.Where(ub => ub.UserId == userId)
                .Include(ub => ub.User)
                .Include(ub => ub.Bourbon)
                .ToListAsync();

            return userBourbons;
        }

    }
}
