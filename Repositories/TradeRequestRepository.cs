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
           return await dbContext.TradeRequests.Where(tr => tr.RequestedFromUserId == userId && tr.Pending == true)
                .Include(tr => tr.RequestedFromUser)
                .Include(tr => tr.RequestedFromBourbon)
                .Include(tr => tr.RequestingUser)
                .Include(tr => tr.RequestingFromBourbon)
                .ToListAsync();
        }

        // Create a New TradeRequest
        public async Task<TradeRequest> AddTradeRequestAsync(TradeRequest newTradeRequest)
        {
            await dbContext.AddAsync(newTradeRequest);
            await dbContext.SaveChangesAsync();
            return newTradeRequest;
        }

        // Update Single Trade Request
        public async Task<TradeRequest> UpdateTradeRequestAsync(int tradeRequestId, TradeRequest updatedTradeRequest)
        {
            var tradeRequestToUpdate = await dbContext.TradeRequests.FirstOrDefaultAsync(tr => tr.Id == tradeRequestId);

            if (tradeRequestToUpdate == null)
            {
                return null;
            }

            tradeRequestToUpdate.RequestingUserId = updatedTradeRequest.RequestingUserId;
            tradeRequestToUpdate.RequestingBourbonId = updatedTradeRequest.RequestingBourbonId;
            tradeRequestToUpdate.RequestedFromUserId = updatedTradeRequest.RequestedFromUserId;
            tradeRequestToUpdate.RequestedFromBourbonId = updatedTradeRequest.RequestedFromBourbonId;
            tradeRequestToUpdate.Pending = updatedTradeRequest.Pending;
            tradeRequestToUpdate.Approved = updatedTradeRequest.Approved;

            await dbContext.SaveChangesAsync();
            return tradeRequestToUpdate;
        }

        // Delete a Single Trade Request
        public async Task<TradeRequest> DeleteTradeRequestAsync(int tradeRequestId)
        {
            var tradeRequestToDelete = await dbContext.TradeRequests.FirstOrDefaultAsync(tr => tr.Id == tradeRequestId);

            if (tradeRequestToDelete == null)
            {
                return null;
            }

            dbContext.TradeRequests.Remove(tradeRequestToDelete);
            await dbContext.SaveChangesAsync();
            return tradeRequestToDelete;
        }
    }
}
