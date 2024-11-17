using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Base;
using Koi.Repositories.InterfaceDAL;

namespace Koi.Repositories.Repository
{
    public class BreedingFormulaRepository : GenericRepository<Breedingformula>, IBreedingFormulaRepository
    {
        private readonly KoiFishGameContext _context;

        public BreedingFormulaRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteAsync(Breedingformula breedingFormula)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Breedingformula>> GetBreedingFormulasByFatherBreedAsync(string fatherBreed)
        {
            return await _context.Breedingformulas
                .Where(b => b.FatherBreed.Contains(fatherBreed))
                .ToListAsync();
        }

        // Lọc BreedingFormula theo MotherBreed
        public async Task<IEnumerable<Breedingformula>> GetBreedingFormulasByMotherBreedAsync(string motherBreed)
        {
            return await _context.Breedingformulas
                .Where(b => b.MotherBreed.Contains(motherBreed))
                .ToListAsync();
        }

        public async Task<IEnumerable<Breedingformula>> GetBreedingFormulasByMutationRateAsync(float mutationRate)
        {
            return await _context.Breedingformulas
                .Where(b => b.MutationRate == mutationRate)
                .ToListAsync();
        }
    }
}
