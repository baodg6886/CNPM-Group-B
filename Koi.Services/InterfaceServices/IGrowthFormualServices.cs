using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IGrowthFormualServices
    {
        Task<GrowthFormual> GetGrowthFormulaByIdAsync(int growthFormulaId);
        Task<IEnumerable<GrowthFormual>> GetAllGrowthFormulasAsync();
        Task AddGrowthFormulaAsync(GrowthFormual growthFormula);
        Task UpdateGrowthFormulaAsync(GrowthFormual growthFormula);
        Task DeleteGrowthFormulaAsync(int growthFormulaId);
    }

   
}
