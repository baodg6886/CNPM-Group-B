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
    public class GrowthFormulaRepository : GenericRepository<Growthformula>, IGrowthFormulaRepository
    {
        private readonly KoiFishGameContext _context;

        public GrowthFormulaRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lọc GrowthFormula theo Breed
        public async Task<IEnumerable<Growthformula>> GetGrowthFormulasByBreedAsync(string breed)
        {
            return await _context.Growthformulas
                .Where(g => g.Breed.Contains(breed))
                .ToListAsync();
        }

        // Lọc GrowthFormula theo GrowthSpeed
        public async Task<IEnumerable<Growthformula>> GetGrowthFormulasByGrowthSpeedAsync(float growthSpeed)
        {
            return await _context.Growthformulas
                .Where(g => g.GrowthSpeed == growthSpeed)
                .ToListAsync();
        }

        // Lọc GrowthFormula theo Age
        public async Task<IEnumerable<Growthformula>> GetGrowthFormulasByAgeAsync(int age)
        {
            return await _context.Growthformulas
                .Where(g => g.Age == age)
                .ToListAsync();
        }
    }
}
