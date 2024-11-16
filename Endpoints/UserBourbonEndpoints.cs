using BEBourbonCollective.Interfaces;

namespace BEBourbonCollective.Endpoints
{
    public class UserBourbonEndpoints
    {
        public static void Map(WebApplication app)
        {
            // Get All UserBourbons
            app.MapGet("/userBourbons", async (IUserBourbonService userBourbonService, int userId) =>
            {
                return await userBourbonService.GetAllUserBourbons(userId);
            });
        }
    }
}
