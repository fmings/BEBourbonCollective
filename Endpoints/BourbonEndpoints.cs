using BEBourbonCollective.Interfaces;

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
        }
    }
}
