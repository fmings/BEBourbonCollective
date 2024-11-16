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

        public async Task<List<Bourbon>> GetAllBourbonsAsync()
        {
            return await _bourbonRepository.GetAllBourbonsAsync();
        }

        public async Task<Bourbon> AddBourbonAsync(Bourbon newBourbon)
        {
            return await _bourbonRepository.AddBourbonAsync(newBourbon);
        }

        public async Task<Bourbon?> UpdateSingleBourbonAsync(int id, Bourbon updatedBourbon)
        {
            return await _bourbonRepository.UpdateSingleBourbonAsync(id, updatedBourbon);
        }

        public async Task<Bourbon?> DeleteSingleBourbonAsync(int id)
        {
            return await _bourbonRepository.DeleteSingleBourbonAsync(id);
        }
    }
}
