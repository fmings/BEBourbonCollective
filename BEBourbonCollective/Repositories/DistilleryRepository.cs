using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBourbonCollective.Repositories
{
    public class DistilleryRepository : IDistilleryRepository
    {
        private readonly BourbonCollectiveDbContext dbContext;

        public DistilleryRepository(BourbonCollectiveDbContext context)
        {
            dbContext = context;
        }

        // Get All Distilleries
        public async Task<List<Distillery>> GetAllDistilleries()
        {
            return await dbContext.Distilleries.ToListAsync();
        }

        // Create a New Distillery
        public async Task<Distillery> AddDistilleryAsync(Distillery newDistillery)
        {
            await dbContext.Distilleries.AddAsync(newDistillery);
            await dbContext.SaveChangesAsync();
            return newDistillery;
        }

        // Update a Single Distillery
        public async Task<Distillery> UpdateDistilleryAsync(int distilleryId, Distillery updatedDistillery)
        {
            var distilleryToUpdate = await dbContext.Distilleries.FirstOrDefaultAsync(d => d.Id == distilleryId);

            if (distilleryToUpdate == null)
            {
                return null;
            }

            distilleryToUpdate.Name = updatedDistillery.Name;
            distilleryToUpdate.City = updatedDistillery.City;
            distilleryToUpdate.State = updatedDistillery.State;

            await dbContext.SaveChangesAsync();
            return distilleryToUpdate;
        }
    }
}
