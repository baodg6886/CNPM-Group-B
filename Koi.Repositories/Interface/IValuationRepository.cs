using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IValuationRepository : IGenericRepository<Valuation>
    {
        Task<Valuation> GetByIdAsync(int id);
        Task<IEnumerable<Valuation>> GetAllAsync();
        Task DeleteAsync(Valuation valuation);
    }
}
