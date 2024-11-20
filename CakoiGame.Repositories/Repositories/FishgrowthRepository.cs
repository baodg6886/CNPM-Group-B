using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CakoiGame.Repositories.Interfaces;
using CakoiGame.Repositories.Entities;

namespace CakoiGame.Repositories.Repositories
{
    public class FishgrowthRepository : IFishgrowthRepository
    {
        private readonly CakoiContext _context;

        public FishgrowthRepository(CakoiContext context)
        {
            _context = context;
        }

   
        public async Task<List<Fishgrowth>> GetAllAsync()
        {
            return await _context.Fishgrowths.ToListAsync();
        }

        public async Task<Fishgrowth> GetByIdAsync(int id)
        {
            return await _context.Fishgrowths
                                 .FirstOrDefaultAsync(fg => fg.Id == id);
        }


        public async Task AddAsync(Fishgrowth fishgrowth)
        {
            await _context.Fishgrowths.AddAsync(fishgrowth);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fishgrowth fishgrowth)
        {
            _context.Fishgrowths.Update(fishgrowth);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var fishgrowth = await _context.Fishgrowths
                                           .FirstOrDefaultAsync(fg => fg.Id == id);

            if (fishgrowth != null)
            {
                _context.Fishgrowths.Remove(fishgrowth);
                await _context.SaveChangesAsync();
            }
        }
    }
}

