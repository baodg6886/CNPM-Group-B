using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Models;
using Koi.Repositories.Interface;


namespace Koi.Repositories.Repositories
{
    public class ValuationRepository : GenericRepository<Valuation>, IValuationRepository
    {
        private readonly KoiFishGameContext _context;

        public ValuationRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }
      

        public async Task<Valuation> GetValuationByBreedAsync(string breed)
        {
            return await _context.Valuations
                                 .FirstOrDefaultAsync(v => v.Breed == breed);
        }

 
        public async Task<IEnumerable<Valuation>> GetValuationsByAgeAsync(int age)
        {
            return await _context.Valuations
                                 .Where(v => v.Age == age)
                                 .ToListAsync();
        }

        
        public async Task<IEnumerable<Valuation>> GetValuationsByGenderAsync(GenderKoi gender)
        {
            return await _context.Valuations
                                 .Where(v => v.Gender == gender)
                                 .ToListAsync();
        }
    }
}
