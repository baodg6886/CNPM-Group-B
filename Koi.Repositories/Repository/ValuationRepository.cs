using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Base;
using Koi.Repositories.InterfaceDAL;

namespace Koi.Repositories.Repository
{
    public class ValuationRepository : GenericRepository<Valuation>, IValuationRepository
    {
        private readonly KoiFishGameContext _context;

        public ValuationRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lọc Valuation theo Breed
        public async Task<IEnumerable<Valuation>> GetValuationsByBreedAsync(string breed)
        {
            return await _context.Valuations
                .Where(v => v.Breed.Contains(breed))
                .ToListAsync();
        }

        // Lọc Valuation theo Age
        public async Task<IEnumerable<Valuation>> GetValuationsByAgeAsync(int age)
        {
            return await _context.Valuations
                .Where(v => v.Age == age)
                .ToListAsync();
        }

        // Lọc Valuation theo Mutation
        public async Task<IEnumerable<Valuation>> GetValuationsByMutationAsync(bool mutation)
        {
            return await _context.Valuations
                .Where(v => v.Mutation == mutation)
                .ToListAsync();
        }

        // Lọc Valuation theo Gender
        public async Task<IEnumerable<Valuation>> GetValuationsByGenderAsync(string gender)
        {
            return await _context.Valuations
                .Where(v => v.Gender.Equals(gender))
                .ToListAsync();
        }
    }
}
