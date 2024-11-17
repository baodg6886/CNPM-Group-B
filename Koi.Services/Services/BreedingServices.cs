using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class BreedingServices : IBreedingServices
    {
        private readonly IBreedingRepository _breedingRepository;

        public BreedingServices(IBreedingRepository breedingRepository)
        {
            _breedingRepository = breedingRepository;
        }

        public async Task<Breeding> GetBreedingByIdAsync(int breedingId)
        {
            var breeding = await _breedingRepository.GetByIdAsync(breedingId);
            if (breeding == null)
            {
                throw new KeyNotFoundException("Breeding not found.");
            }
            return breeding;
        }

        public async Task<IEnumerable<Breeding>> GetAllBreedingsAsync()
        {
            return await _breedingRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Breeding>> GetBreedingsByStatusAsync(string status)
        {
            return await _breedingRepository.GetBreedingsByStatusAsync(status);
        }

        public async Task StartBreedingAsync(Breeding breeding)
        {
            if (breeding.Father == null || breeding.Mother == null)
            {
                throw new ArgumentException("Both father and mother KoiFish must be provided.");
            }

            breeding.Status = "InProgress";
            breeding.StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
            breeding.EndDate = breeding.StartDate.AddMonths(3);
            await _breedingRepository.AddAsync(breeding);
        }

        public async Task CompleteBreedingAsync(int breedingId)
        {
            var breeding = await _breedingRepository.GetByIdAsync(breedingId);
            if (breeding == null)
            {
                throw new KeyNotFoundException("Breeding not found.");
            }

            breeding.Status = "Hatched";
            breeding.EndDate = DateOnly.FromDateTime(DateTime.UtcNow);
            await _breedingRepository.UpdateAsync(breeding);
        }

        public async Task AddOffspringToBreedingAsync(int breedingId, List<Koifish> offspring)
        {
            var breeding = await _breedingRepository.GetByIdAsync(breedingId);
            if (breeding == null)
            {
                throw new KeyNotFoundException("Breeding not found.");
            }

    
            await _breedingRepository.UpdateAsync(breeding);
        }
    }

}
