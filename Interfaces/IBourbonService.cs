using BEBourbonCollective.Models;

namespace BEBourbonCollective.Interfaces
{
    public interface IBourbonService
    {
        Task<List<Bourbon>> GetAllBourbonsAsync();

    }
}
