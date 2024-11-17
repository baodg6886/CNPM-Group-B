using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IBreedingRepository : IGenericRepository<Breeding>
    {
        Task<IEnumerable<Breeding>> GetBreedingByStatusAsync(BreedingStatus status);
        Task<Breeding> GetBreedingByIdAsync(int breedingId);
    
        Task<IEnumerable<Breeding>> GetAllBreedingAsync();
        Task<IEnumerable<Breeding>> GetOngoingBreedingsAsync();
        Task<Breeding> GetBreedingByParentsAsync(int fatherid, int motherid);
        Task<IEnumerable<Breeding>> GetByStatusAsync(BreedingStatus status);
    }

}
