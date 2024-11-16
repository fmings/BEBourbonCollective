using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Services
{
    public class TradeRequestService : ITradeRequestService
    {
        private readonly ITradeRequestRepository _tradeRequestRepository;

        public TradeRequestService(ITradeRequestRepository tradeRequestRepository)
        {
            _tradeRequestRepository = tradeRequestRepository;
        }
        public async Task<List<TradeRequest>> GetAllPendingTradeRequestsByUser(int userId)
        {
            return await GetAllPendingTradeRequestsByUser(userId);
        }
    }
}
