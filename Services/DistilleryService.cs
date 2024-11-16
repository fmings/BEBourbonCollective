using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;

namespace BEBourbonCollective.Services
{
    public class DistilleryService : IDistilleryService
    {
        private readonly IDistilleryRepository _distilleryRepository;

        public DistilleryService(IDistilleryRepository distilleryRepository)
        {
            _distilleryRepository = distilleryRepository;
        }
        public async Task<List<Distillery>> GetAllDistilleries()
        {
            return await _distilleryRepository.GetAllDistilleries();
        }

        public async Task<Distillery> AddDistilleryAsync(Distillery newDistillery)
        {
            return await _distilleryRepository.AddDistilleryAsync(newDistillery);
        }
    }
}
