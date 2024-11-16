using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Endpoints
{
    public class TradeRequestEndpoints
    {
        public static void Map(WebApplication app)
        {
            // Get All Pending TradeRequests By UserId
            app.MapGet("/tradeRequests/user/{userId}", async (ITradeRequestService tradeRequestService, int userId) =>
            {
                return await tradeRequestService.GetAllPendingTradeRequestsByUser(userId);
            });

            // Add a New Trade Request
            app.MapPost("/tradeRequests", async (ITradeRequestService tradeRequestService, TradeRequest newTradeRequest) =>
            {
                return await tradeRequestService.AddTradeRequestAsync(newTradeRequest);
            });

            // Update an Existing TradeRequest
            app.MapPut("/tradeRequests/{tradeRequestId}", async (ITradeRequestService tradeRequestService, int tradeRequestId, TradeRequest updatedTradeRequest) =>
            {
                return await tradeRequestService.UpdateTradeRequestAsync(tradeRequestId, updatedTradeRequest);
            });
        }
    }
}
