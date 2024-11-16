using BEBourbonCollective.Interfaces;

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
        }
    }
}
