using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Services
{
    public class BourbonService : IBourbonService
    {
        private readonly IBourbonRepository _bourbonRepository;

        public BourbonService(IBourbonRepository bourbonRepository)
        {
            _bourbonRepository = bourbonRepository;
        }

        public async Task <List<Bourbon>> GetAllBourbonsAsync()
        {
            return await _bourbonRepository.GetAllBourbonsAsync();
        }
    }
}
