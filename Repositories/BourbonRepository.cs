using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBourbonCollective.Repositories
{
    public class BourbonRepository : IBourbonRepository
    {
        private readonly BourbonCollectiveDbContext dbContext;

        public BourbonRepository(BourbonCollectiveDbContext context)
        {
            dbContext = context;
        }

        // Get All Bourbons
        public async Task<List<Bourbon>> GetAllBourbonsAsync()
        {
            return await dbContext.Bourbons
                .Include(b => b.Distillery)
                .ToListAsync();
        }
    }
}
