using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBourbonCollective.Repositories
{
    public class TradeRequestRepository :ITradeRequestRepository
    {
        private readonly BourbonCollectiveDbContext dbContext;

        public TradeRequestRepository(BourbonCollectiveDbContext context)
        {
            dbContext = context;
        }

        // Get All Pending TradeRequests by UserId
        public async Task<List<TradeRequest>> GetAllPendingTradeRequestsByUser(int userId)
        {
           return await dbContext.TradeRequests.Where(tr => tr.RequestedFromUserId == userId && tr.Pending == true).ToListAsync();
        }
    }
}
