using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;
using CakoiGame.Repositories.Interfaces;
using CakoiGame.Services.Interfaces;

namespace CakoiGame.Services.Services
{
    public class FishgrowthServices : IFishgrowthServices
    {
        private readonly IFishgrowthRepository _fishgrowthRepository;


        public FishgrowthServices(IFishgrowthRepository fishgrowthRepository)
        {
            _fishgrowthRepository = fishgrowthRepository;
        }


        public async Task<List<Fishgrowth>> GetAllFishgrowthsAsync()
        {
            return await _fishgrowthRepository.GetAllAsync();
        }


        public async Task<Fishgrowth> GetFishgrowthByIdAsync(int id)
        {
            return await _fishgrowthRepository.GetByIdAsync(id);
        }


        public async Task AddFishgrowthAsync(Fishgrowth fishgrowth)
        {
            await _fishgrowthRepository.AddAsync(fishgrowth);
        }


        public async Task UpdateFishgrowthAsync(Fishgrowth fishgrowth)
        {
            await _fishgrowthRepository.UpdateAsync(fishgrowth);
        }

        public async Task DeleteFishgrowthAsync(int id)
        {
            await _fishgrowthRepository.DeleteAsync(id);
        }
    }
}
