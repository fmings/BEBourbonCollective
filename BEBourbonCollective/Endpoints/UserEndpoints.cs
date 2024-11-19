using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using BEBourbonCollective.Services;
using Microsoft.AspNetCore.Mvc;

namespace BEBourbonCollective.Endpoints
{
    public class UserEndpoints
    {
        public static void Map(WebApplication app)
        {
            // CHECK USERS
            app.MapGet("/users/checkUser/{uid}", async ([FromServices] IUserService userService, string uid) => 
            {
                var user = await userService.CheckUserAsync(uid);

                if (user == null)
                {
                    return Results.NotFound("user not found");
                }
                return Results.Ok(user);
            });

            // Register user
            app.MapPost("/users/register", async (IUserService userService, User user) =>
            {
                var newUser = await userService.RegisterUserAsync(user);
                return Results.Created($"/users/{newUser.Id}", newUser);
            });

            // Get Single User
            app.MapGet("/users/{id}", async (IUserService userService, int id) =>
            {
                var user = await userService.GetSingleUserAsync(id);

                if (user == null)
                {
                    return Results.NotFound("user not found");
                }
                return Results.Ok(user);
            });

            // Get All Users
            app.MapGet("/users", async (IUserService userService) =>
            {
                return await userService.GetAllUsersAsync();
            });

            // Update Single User
            app.MapPut("/users/{id}", async (IUserService userService, int id, User updatedUser) =>
            {
                var userToUpdate = await userService.UpdateSingleUserAsync(id, updatedUser);
                return Results.Ok(userToUpdate);

            });
        }
    }
}
