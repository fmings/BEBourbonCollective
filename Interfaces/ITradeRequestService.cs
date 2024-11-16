﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface ITradeRequestService
    {
        Task<List<TradeRequest>> GetAllPendingTradeRequestsByUser(int userId);
        Task<TradeRequest> AddTradeRequestAsync(TradeRequest newTradeRequest);
        Task<TradeRequest> UpdateTradeRequestAsync(int tradeRequestId, TradeRequest updatedTradeRequest);
    }
}
