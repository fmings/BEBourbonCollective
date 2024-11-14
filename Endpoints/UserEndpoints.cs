using BEBourbonCollective.Interfaces;

namespace BEBourbonCollective.Endpoints
{
    public class UserEndpoints
    {
        public static void Map(WebApplication app)
        {
            // CHECK USERS
            app.MapGet("/checkUser/{uid}", async (IUserService userService, string uid) => 
            {
                var user = await userService.CheckUserAsync(uid);

                if (user == null)
                {
                    return Results.NotFound("user not found");
                }
                return Results.Ok(user);
            });
        }
    }
}
