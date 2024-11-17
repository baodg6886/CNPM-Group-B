using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IGrowthFormulaRepository : IGenericRepository<Growthformula>
    {
        // Lọc GrowthFormula theo Breed
        Task<IEnumerable<Growthformula>> GetGrowthFormulasByBreedAsync(string breed);

        // Lọc GrowthFormula theo GrowthSpeed
        Task<IEnumerable<Growthformula>> GetGrowthFormulasByGrowthSpeedAsync(float growthSpeed);

        // Lọc GrowthFormula theo Age
        Task<IEnumerable<Growthformula>> GetGrowthFormulasByAgeAsync(int age);
        Task DeleteAsync(Growthformula growthFormula);
    }
}
