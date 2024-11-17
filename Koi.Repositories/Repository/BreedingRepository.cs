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
    public class BreedingRepository : GenericRepository<Breeding>, IBreedingRepository
    {
        private readonly KoiFishGameContext _context;

        public BreedingRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lọc Breeding theo FatherId
        public async Task<IEnumerable<Breeding>> GetBreedingsByFatherIdAsync(int fatherId)
        {
            return await _context.Breedings
                .Where(b => b.FatherId == fatherId)
                .ToListAsync();
        }

        // Lọc Breeding theo MotherId
        public async Task<IEnumerable<Breeding>> GetBreedingsByMotherIdAsync(int motherId)
        {
            return await _context.Breedings
                .Where(b => b.MotherId == motherId)
                .ToListAsync();
        }

        // Lọc Breeding theo Type
        public async Task<IEnumerable<Breeding>> GetBreedingsByTypeAsync(string type)
        {
            return await _context.Breedings
                .Where(b => b.Type.Contains(type))
                .ToListAsync();
        }

        // Lọc Breeding theo Status
        public async Task<IEnumerable<Breeding>> GetBreedingsByStatusAsync(string status)
        {
            return await _context.Breedings
                .Where(b => b.Status.Contains(status))
                .ToListAsync();
        }
    }
}
