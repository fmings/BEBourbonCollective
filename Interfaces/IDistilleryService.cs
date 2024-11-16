﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IDistilleryService
    {
        Task<List<Distillery>> GetAllDistilleries();
        Task<Distillery> AddDistilleryAsync(Distillery newDistillery);
    }
}
