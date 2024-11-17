using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Repositories
{
    public class BreedingFormulaRepository : GenericRepository<BreedingFormula>, IBreedingFormulaRepository
    { 
        private readonly KoiFishGameContext _context;

       
        public BreedingFormulaRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
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

        public new async Task<BreedingFormula?> GetByIdAsync(int id)
        {
            return await _context.BreedingFormulas
                                 .FirstOrDefaultAsync(bf => bf.BreedingFormulaID == id);
        }

        public async Task<IEnumerable<BreedingFormula>> GetAllAsync()
        {
            return await _context.BreedingFormulas.ToListAsync();
        }

     
        public async Task AddAsync(BreedingFormula entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.BreedingFormulas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BreedingFormula entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.BreedingFormulas.Update(entity);
            await _context.SaveChangesAsync();
        }

    
        public async Task DeleteAsync(int id)
        {
            var breedingFormula = await _context.BreedingFormulas.FindAsync(id);
            if (breedingFormula == null)
            {
                throw new KeyNotFoundException("Breeding formula not found.");
            }

            _context.BreedingFormulas.Remove(breedingFormula);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(BreedingFormula breedingFormula)
        {
            if (breedingFormula == null)
            {
                throw new ArgumentNullException(nameof(breedingFormula));
            }

            _context.BreedingFormulas.Remove(breedingFormula);
            await _context.SaveChangesAsync();
        }
    }
}
