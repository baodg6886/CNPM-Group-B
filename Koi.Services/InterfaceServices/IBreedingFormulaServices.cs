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
       
        Task<Breedingformula> GetBreedingFormulaByIdAsync(int breedingFormulaId);
        Task<IEnumerable<Breedingformula>> GetAllBreedingFormulasAsync();
        Task AddBreedingFormulaAsync(Breedingformula breedingFormula);
        Task UpdateBreedingFormulaAsync(Breedingformula breedingFormula);
        Task DeleteBreedingFormulaAsync(int breedingFormulaId);
    }
}
