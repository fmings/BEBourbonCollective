﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface ITradeRequestService
    {
        Task<List<TradeRequest>> GetAllPendingTradeRequestsByUser(int userId);
    }
}
