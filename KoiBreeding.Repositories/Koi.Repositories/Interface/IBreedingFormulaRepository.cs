using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

public interface IBreedingFormulaRepository : IGenericRepository<BreedingFormula>
{
    Task<BreedingFormula?> GetByFatherAndMotherBreedAsync(string fatherBreed, string motherBreed);
    Task<IEnumerable<BreedingFormula>> GetAllFormulasAsync();
}
