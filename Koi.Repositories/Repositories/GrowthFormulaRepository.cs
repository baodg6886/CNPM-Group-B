using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Models;

namespace Koi.Repositories.Repositories
{
    public class GrowthFormulaRepository : GenericRepository<GrowthFormual>, IGrowthFormulaRepository
    {
        private readonly KoiFishGameContext _context;
        public GrowthFormulaRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteAsync(GrowthFormual growthFormula)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GrowthFormual>> GetByBreedAsync(string breed)
        {
            return await _context.GrowthFormulas
                .Where(g => g.Breed == breed)
                .ToListAsync();
        }
    }
}
