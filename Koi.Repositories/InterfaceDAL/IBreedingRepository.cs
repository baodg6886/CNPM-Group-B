using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IBreedingRepository : IGenericRepository<Breeding>
    {
        // Lọc Breeding theo FatherId
        Task<IEnumerable<Breeding>> GetBreedingsByFatherIdAsync(int fatherId);

        // Lọc Breeding theo MotherId
        Task<IEnumerable<Breeding>> GetBreedingsByMotherIdAsync(int motherId);

        // Lọc Breeding theo Type
        Task<IEnumerable<Breeding>> GetBreedingsByTypeAsync(string type);

        // Lọc Breeding theo Status
        Task<IEnumerable<Breeding>> GetBreedingsByStatusAsync(string status);
    }
}
