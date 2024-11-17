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
        Task<Growthformula> GetGrowthFormulaByIdAsync(int growthFormulaId);
        Task<IEnumerable<Growthformula>> GetAllGrowthFormulasAsync();
        Task AddGrowthFormulaAsync(Growthformula growthFormula);
        Task UpdateGrowthFormulaAsync(Growthformula growthFormula);
        Task DeleteGrowthFormulaAsync(int growthFormulaId);
    }

   
}
