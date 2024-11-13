using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    internal class BreedingServices :IBreedingServices 
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

        public async Task<IEnumerable<Breeding>> GetBreedingsByStatusAsync(BreedingStatus status)
        {
            return await _breedingRepository.GetByStatusAsync(status);
        }

        public async Task StartBreedingAsync(Breeding breeding)
        {
            // Kiểm tra tính hợp lệ của thông tin breeding
            if (breeding.Father == null || breeding.Mother == null)
            {
                throw new InvalidOperationException("Both father and mother KoiFish must be provided.");
            }

            breeding.Status = BreedingStatus.InProgress;
            breeding.StartDate = DateTime.Now;
            breeding.EndDate = breeding.StartDate.AddMonths(3); // Ví dụ, thời gian sinh sản là 3 tháng
            await _breedingRepository.AddAsync(breeding);
        }

        public async Task CompleteBreedingAsync(int breedingId)
        {
            var breeding = await _breedingRepository.GetByIdAsync(breedingId);
            if (breeding == null)
            {
                throw new KeyNotFoundException("Breeding not found.");
            }

            breeding.Status = BreedingStatus.Hatched;
            breeding.EndDate = DateTime.Now;
            await _breedingRepository.UpdateAsync(breeding);
        }

        public async Task AddOffspringToBreedingAsync(int breedingId, List<KoiFish> offspring)
        {
            var breeding = await _breedingRepository.GetByIdAsync(breedingId);
            if (breeding == null)
            {
                throw new KeyNotFoundException("Breeding not found.");
            }

            breeding.Offspring.AddRange(offspring);
            await _breedingRepository.UpdateAsync(breeding);
        }
    }
}
