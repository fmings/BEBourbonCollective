﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IDistilleryRepository
    {
        Task<List<Distillery>> GetAllDistilleries();
        Task<Distillery> AddDistilleryAsync(Distillery newDistillery);
        Task<Distillery> UpdateDistilleryAsync(int distilleryId, Distillery updatedDistillery);
    }
}
