using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Endpoints
{
    public class UserBourbonEndpoints
    {
        public static void Map(WebApplication app)
        {
            // Get All UserBourbons
            app.MapGet("/userBourbons", async (IUserBourbonService userBourbonService, int userId) =>
            {
                return await userBourbonService.GetAllUserBourbonsAsync(userId);
            });

            // Add a UserBourbon
            app.MapPost("/userBourbons", async (IUserBourbonService userBourbonService, UserBourbon newUserBourbon) =>
            {
                return await userBourbonService.AddUserBourbonAsync(newUserBourbon);
            });

            // Update a Single UserBourbon
            app.MapPatch("/userBourbons/{userBourbonId}", async (IUserBourbonService userBourbonService, int userBourbonId, UserBourbon updatedUserBourbon) =>
            {
                var userBourbonToUpdate = await userBourbonService.UpdateUserBourbonAsync(userBourbonId, updatedUserBourbon);
                return Results.Ok(userBourbonToUpdate);
            });
        }
    }
}
