using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IBreedingFormulaRepository : IGenericRepository<Breedingformula>
    {
        Task DeleteAsync(Breedingformula breedingFormula);

        // Lọc BreedingFormula theo FatherBreed
        Task<IEnumerable<Breedingformula>> GetBreedingFormulasByFatherBreedAsync(string fatherBreed);

        // Lọc BreedingFormula theo MotherBreed
        Task<IEnumerable<Breedingformula>> GetBreedingFormulasByMotherBreedAsync(string motherBreed);

        // Lọc BreedingFormula theo MutationRate
        Task<IEnumerable<Breedingformula>> GetBreedingFormulasByMutationRateAsync(float mutationRate);
    }
}
