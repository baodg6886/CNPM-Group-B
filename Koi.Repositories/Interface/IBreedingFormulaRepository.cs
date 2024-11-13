using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IBreedingFormulaRepository : IGenericRepository<BreedingFormula>
    {
        Task<BreedingFormula?> GetByFatherAndMotherBreedAsync(string fatherBreed, string motherBreed);
        Task<IEnumerable<BreedingFormula>> GetAllFormulasAsync();
        Task DeleteAsync(BreedingFormula breedingFormula);
    }
}