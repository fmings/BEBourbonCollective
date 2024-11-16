using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Endpoints
{
    public class BourbonEndpoints
    {
        public static void Map(WebApplication app)
        {
            // Get All Bourbons
            app.MapGet("/bourbons", async (IBourbonService bourbonService) =>
            {
                return await bourbonService.GetAllBourbonsAsync();
            });

            // Add a Bourbon
            app.MapPost("/bourbons", async (IBourbonService bourbonService, Bourbon newBourbon) =>
            {
                return await bourbonService.AddBourbonAsync(newBourbon);
            });

            // Update a Single Bourbon
            app.MapPut("/bourbons/{id}", async (IBourbonService bourbonService, int id, Bourbon updatedBourbon) =>
            {
                return await bourbonService.UpdateSingleBourbonAsync(id, updatedBourbon);
            });

            // Delete a Single Bourbon
            app.MapDelete("bourbons/{id}", async (IBourbonService bourbonService, int id) =>
            {
                return await bourbonService.DeleteSingleBourbonAsync(id);
            });
        }
    }
}
