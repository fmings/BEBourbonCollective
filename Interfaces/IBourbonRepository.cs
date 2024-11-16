using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IBourbonRepository
    {
        Task<List<Bourbon>> GetAllBourbonsAsync();
    }
}
