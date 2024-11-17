using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IValuationRepository : IGenericRepository<Valuation>
    {
        // Lọc Valuation theo Breed
        Task<IEnumerable<Valuation>> GetValuationsByBreedAsync(string breed);

        // Lọc Valuation theo Age
        Task<IEnumerable<Valuation>> GetValuationsByAgeAsync(int age);

        // Lọc Valuation theo Mutation
        Task<IEnumerable<Valuation>> GetValuationsByMutationAsync(bool mutation);

        // Lọc Valuation theo Gender
        Task<IEnumerable<Valuation>> GetValuationsByGenderAsync(string gender);
    }
}
