﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface ITradeRequestRepository
    {
        Task<List<TradeRequest>> GetAllPendingTradeRequestsByUser(int userId);
        Task<TradeRequest> AddTradeRequestAsync(TradeRequest newTradeRequest);
    }
}
