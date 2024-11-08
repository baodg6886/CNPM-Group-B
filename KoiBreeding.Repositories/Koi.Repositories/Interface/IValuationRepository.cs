using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;

namespace Koi.Repositories.Models
{
    public interface IValuationRepository : IGenericRepository<Valuation>
    {
        Task<Valuation> GetValuationByBreedAsync(string breed);
        Task<IEnumerable<Valuation>> GetValuationsByAgeAsync(int age);
        Task<IEnumerable<Valuation>> GetValuationsByGenderAsync(GenderKoi gender);
    }
}
