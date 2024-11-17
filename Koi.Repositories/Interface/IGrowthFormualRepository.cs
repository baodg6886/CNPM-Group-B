using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IGrowthFormulaRepository : IGenericRepository<GrowthFormual>
    {
        Task DeleteAsync(GrowthFormual growthFormula);
        Task<IEnumerable<GrowthFormual>> GetByBreedAsync(string breed); 
    }
}
