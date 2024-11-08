using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

public class BreedingFormulaRepository : IBreedingFormulaRepository
{
    private readonly KoiFishGameContext _context;

    public BreedingFormulaRepository(KoiFishGameContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<BreedingFormula?> GetByFatherAndMotherBreedAsync(string fatherBreed, string motherBreed)
    {
        return await _context.BreedingFormulas
                             .FirstOrDefaultAsync(bf => bf.FatherBreed == fatherBreed && bf.MotherBreed == motherBreed);
    }

    public async Task<IEnumerable<BreedingFormula>> GetAllFormulasAsync()
    {
        return await _context.BreedingFormulas.ToListAsync();
    }

    public Task<BreedingFormula> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BreedingFormula>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(BreedingFormula entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(BreedingFormula entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
