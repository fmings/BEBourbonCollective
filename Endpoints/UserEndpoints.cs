using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.AspNetCore.Mvc;

namespace BEBourbonCollective.Endpoints
{
    public class UserEndpoints
    {
        public static void Map(WebApplication app)
        {
            // CHECK USERS
            app.MapGet("/checkUser/{uid}", async ([FromServices] IUserService userService, string uid) => 
            {
                var user = await userService.CheckUserAsync(uid);

                if (user == null)
                {
                    return Results.NotFound("user not found");
                }
                return Results.Ok(user);
            });

            // Register user
            app.MapPost("/register", async (IUserService userService, User user) =>
            {
                var newUser = await userService.RegisterUserAsync(user);
                return Results.Created($"/users/{newUser.Id}", newUser);
            });
        }
    }
}
