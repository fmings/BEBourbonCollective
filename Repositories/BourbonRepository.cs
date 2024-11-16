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

        // Add a New Bourbon
        public async Task<Bourbon> AddBourbonAsync(Bourbon newBourbon)
        {
            await dbContext.Bourbons.AddAsync(newBourbon);
            await dbContext.SaveChangesAsync();
            return newBourbon;
        }

        // Update a Single Bourbon
        public async Task<Bourbon?> UpdateSingleBourbonAsync(int id, Bourbon updatedBourbon)
        {
            var bourbonToUpdate = await dbContext.Bourbons.FirstOrDefaultAsync(u => u.Id == id);

            if (bourbonToUpdate == null)
            {
                return null;
            }

            bourbonToUpdate.DistilleryId = updatedBourbon.DistilleryId;
            bourbonToUpdate.Name = updatedBourbon.Name;
            bourbonToUpdate.OpenBottle = updatedBourbon.OpenBottle;
            bourbonToUpdate.EmptyBottle = updatedBourbon.EmptyBottle;

            await dbContext.SaveChangesAsync();
            return bourbonToUpdate;
        }
    }
}
