using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories.Repositories
{
    public class BreedingRepository : GenericRepository<Breeding>, IBreedingRepository
    {
        private readonly KoiFishGameContext _context;

        public BreedingRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Breeding>> GetBreedingByStatusAsync(BreedingStatus status)
        {
            return await _context.Breedings
                                 .Where(b => b.Status == status)
                                 .Include(b => b.Father)
                                 .Include(b => b.Mother)
                                 .Include(b => b.Offspring)
                                 .ToListAsync();
        }

        public async Task<Breeding> GetBreedingByIdAsync(int breedingId)
        {
            var breeding = await _context.Breedings
                                          .Include(b => b.Father)
                                          .Include(b => b.Mother)
                                          .Include(b => b.Offspring)
                                          .FirstOrDefaultAsync(b => b.BreedingID == breedingId);

            if (breeding == null)
            {
                throw new KeyNotFoundException($"Breeding with ID {breedingId} not found.");
            }

            return breeding;
        }

        public async Task AddBreedingAsync(Breeding breeding)
        {
            if (breeding == null)
            {
                throw new ArgumentNullException(nameof(breeding), "Breeding cannot be null.");
            }

            await _context.Breedings.AddAsync(breeding);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBreedingStatusAsync(int breedingId, BreedingStatus newStatus)
        {
            var breeding = await _context.Breedings
                                          .FirstOrDefaultAsync(b => b.BreedingID == breedingId);

            if (breeding == null)
            {
                throw new KeyNotFoundException($"Breeding with ID {breedingId} not found.");
            }

            breeding.Status = newStatus;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Breeding>> GetAllBreedingAsync()
        {
            return await _context.Breedings
                                 .Include(b => b.Father)
                                 .Include(b => b.Mother)
                                 .Include(b => b.Offspring)
                                 .ToListAsync();
        }

        // Triển khai phương thức GetOngoingBreedingsAsync
        public async Task<IEnumerable<Breeding>> GetOngoingBreedingsAsync()
        {
            return await _context.Breedings
                                 .Where(b => b.Status == BreedingStatus.InProgress)
                                 .Include(b => b.Father)
                                 .Include(b => b.Mother)
                                 .Include(b => b.Offspring)
                                 .ToListAsync();
        }

        // Triển khai phương thức GetBreedingByParentsAsync
        public async Task<Breeding> GetBreedingByParentsAsync(int fatherid, int motherid)
        {
            var breeding = await _context.Breedings
                                         .Include(b => b.Father)
                                         .Include(b => b.Mother)
                                         .Include(b => b.Offspring)
                                         .FirstOrDefaultAsync(b => b.Father.UserID == fatherid && b.Mother.UserID == motherid);

            if (breeding == null)
            {
                throw new KeyNotFoundException($"Breeding with FatherID {fatherid} and MotherID {motherid} not found.");
            }

            return breeding;
        }
    }
}
