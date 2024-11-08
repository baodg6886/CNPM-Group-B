using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using static Koi.Repositories.Repositories.PondRepository;

namespace Koi.Repositories.Repositories
{
  
    
        public class PondRepository : GenericRepository<Pond>, IPondRepository
        {
            private readonly KoiFishGameContext _context;

            public PondRepository(KoiFishGameContext context) : base(context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Pond>> GetPondsByUserIdAsync(int userId)
            {
                return await _context.Ponds
                                     .Where(predicate: p => p.PondID == userId)
                                     .ToListAsync();
            }

        public async Task<Pond?> GetPondByIdAsync(int id)
        {
            return await _context.Ponds
                             .FirstOrDefaultAsync(p => p.PondID == id);
        }
    }

    
}
