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
    public class KoifishRepository : GenericRepository<Koifish>, IKoifishRepository
    {
        private readonly KoiFishGameContext _context;

        public KoifishRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lọc cá Koi theo giống
        public async Task<IEnumerable<Koifish>> GetKoifishByBreedAsync(string breed)
        {
            return await _context.Koifishes
                .Where(k => k.Breed.Contains(breed))
                .ToListAsync();
        }

        // Lọc cá Koi theo trạng thái
        public async Task<IEnumerable<Koifish>> GetKoifishByStatusAsync(string status)
        {
            return await _context.Koifishes
                .Where(k => k.Status == status)
                .ToListAsync();
        }

        // Tìm cá Koi theo tên
        public async Task<Koifish> GetKoifishByNameAsync(string name)
        {
            return await _context.Koifishes
                .FirstOrDefaultAsync(k => k.Name == name);
        }
     

        // Lọc cá Koi theo khoảng giá
        public async Task<IEnumerable<Koifish>> GetKoifishByPriceRangeAsync(float minPrice, float maxPrice)
        {
            return await _context.Koifishes
                .Where(k => k.Price >= minPrice && k.Price <= maxPrice)
                .ToListAsync();
        }

        // Lọc cá Koi theo độ tuổi
        public async Task<IEnumerable<Koifish>> GetKoifishByAgeAsync(int minAge, int maxAge)
        {
            return await _context.Koifishes
                .Where(k => k.Age >= minAge && k.Age <= maxAge)
                .ToListAsync();
        }
    }
}
