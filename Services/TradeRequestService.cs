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
            return await _tradeRequestRepository.GetAllPendingTradeRequestsByUser(userId);
        }

        public async Task<TradeRequest> AddTradeRequestAsync(TradeRequest newTradeRequest)
        {
            return await _tradeRequestRepository.AddTradeRequestAsync(newTradeRequest);
        }

        public async Task<TradeRequest> UpdateTradeRequestAsync(int tradeRequestId, TradeRequest updatedTradeRequest)
        {
            return await _tradeRequestRepository.UpdateTradeRequestAsync(tradeRequestId, updatedTradeRequest);
        }

        public async Task<TradeRequest> DeleteTradeRequestAsync(int tradeRequestId)
        {
            return await _tradeRequestRepository.DeleteTradeRequestAsync(tradeRequestId);
        }

    }
}
