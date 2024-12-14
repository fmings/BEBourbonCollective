﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IBourbonRepository
    {
        Task <List<Bourbon>> GetAllBourbonsAsync();

        Task <Bourbon> AddBourbonAsync(Bourbon newBourbon);

        Task <Bourbon?> UpdateSingleBourbonAsync(int id, Bourbon newBourbon);

        Task<Bourbon?> DeleteSingleBourbonAsync(int id);

        Task<List<Bourbon?>> SearchBourbonsAsync(string searchValue);


    }
}
