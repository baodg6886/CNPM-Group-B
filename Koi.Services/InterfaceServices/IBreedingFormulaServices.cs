using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IBreedingFormulaServices
    {
        Task<BreedingFormula> GetBreedingFormulaByIdAsync(int breedingFormulaId);
        Task<IEnumerable<BreedingFormula>> GetAllBreedingFormulasAsync();
        Task AddBreedingFormulaAsync(BreedingFormula breedingFormula);
        Task UpdateBreedingFormulaAsync(BreedingFormula breedingFormula);
        Task DeleteBreedingFormulaAsync(int breedingFormulaId);
    }
}
