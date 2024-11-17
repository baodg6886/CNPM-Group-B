using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories
{
    public class PondRepository : GenericRepository<Pond>, IPondRepository
    {
        private readonly KoiFishGameContext _context;

        public PondRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Phân trang hồ cá
        public async Task<IEnumerable<Pond>> GetAllPagingAsync(string search, int offset, int limit)
        {
            var query = _context.Ponds.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Environment.Contains(search)); // Tìm kiếm theo môi trường
            }

            return await query
                .Skip(offset)
                .Take(limit)
                .ToListAsync(); 
        }

        // Lọc hồ cá theo cấp độ
        public async Task<IEnumerable<Pond>> GetPondsByLevelAsync(int level)
        {
            return await _context.Ponds
                .Where(p => p.Level == level)
                .ToListAsync(); 
        }
    }
}
