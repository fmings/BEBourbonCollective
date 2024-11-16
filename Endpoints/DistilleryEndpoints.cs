using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Endpoints
{
    public class DistilleryEndpoints
    {
        public static void Map(WebApplication app)
        {
            // Get All Distilleries
            app.MapGet("/distilleries", async (IDistilleryService distilleryService) =>
            {
                return await distilleryService.GetAllDistilleries();
            });

            app.MapPost("/distilleries", async (IDistilleryService distilleryService, Distillery newDistillery) =>
            {
                return await distilleryService.AddDistilleryAsync(newDistillery);
            });
        }
    }
}
