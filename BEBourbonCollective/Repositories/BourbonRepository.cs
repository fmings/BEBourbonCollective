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
                .OrderBy(b => b.Distillery.Name)
                .ThenBy(b => b.Name)
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
            var bourbonToUpdate = await dbContext.Bourbons.FirstOrDefaultAsync(b => b.Id == id);

            if (bourbonToUpdate == null)
            {
                return null;
            }

            bourbonToUpdate.DistilleryId = updatedBourbon.DistilleryId;
            bourbonToUpdate.Name = updatedBourbon.Name;
            bourbonToUpdate.Image = updatedBourbon.Image;

            await dbContext.SaveChangesAsync();
            return bourbonToUpdate;
        }

        // Delete a Single Bourbon
        public async Task<Bourbon?> DeleteSingleBourbonAsync(int id)
        {
            var bourbonToDelete = await dbContext.Bourbons.FirstOrDefaultAsync(b => b.Id == id);

            if (bourbonToDelete == null)
            {
                return null;
            }
            dbContext.Bourbons.Remove(bourbonToDelete);
            await dbContext.SaveChangesAsync();
            return bourbonToDelete;
        }
    }
}
