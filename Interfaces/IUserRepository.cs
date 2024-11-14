﻿using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> CheckUserAsync(string uid);
    }
}
