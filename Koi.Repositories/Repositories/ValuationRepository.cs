using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Models
{
    public class ValuationRepository : GenericRepository<Valuation>, IValuationRepository
    {
        private readonly KoiFishGameContext _context;

        public ValuationRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lấy thông tin định giá cá theo giống (Breed)
        public async Task<Valuation> GetValuationByBreedAsync(string breed)
        {
            return await _context.Valuations
                                 .FirstOrDefaultAsync(v => v.Breed == breed);
        }

        // Lấy danh sách định giá cá theo độ tuổi (Age)
        public async Task<IEnumerable<Valuation>> GetValuationsByAgeAsync(int age)
        {
            return await _context.Valuations
                                 .Where(v => v.Age == age)
                                 .ToListAsync();
        }

        // Lấy danh sách định giá cá theo giới tính (Gender)
        public async Task<IEnumerable<Valuation>> GetValuationsByGenderAsync(GenderKoi gender)
        {
            return await _context.Valuations
                                 .Where(v => v.Gender == gender)
                                 .ToListAsync();
        }
    }
}
