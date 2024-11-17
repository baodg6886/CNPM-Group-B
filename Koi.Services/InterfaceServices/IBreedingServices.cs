using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IBreedingServices
    {
        Task<Breeding> GetBreedingByIdAsync(int breedingId);
        Task<IEnumerable<Breeding>> GetAllBreedingsAsync();
        Task<IEnumerable<Breeding>> GetBreedingsByStatusAsync(string status);
        Task StartBreedingAsync(Breeding breeding);
        Task CompleteBreedingAsync(int breedingId);
      
        Task AddOffspringToBreedingAsync(int breedingId, List<Koifish> offspring);
    }
}
