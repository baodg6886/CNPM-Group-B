using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Models;
using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Repository
{
    // Kế thừa GenericRepository<Pond> và IPondRepository
    public class PondRepository : GenericRepository<Pond>, IPondRepository
    {
        private readonly KoiFishGameContext _context;

        // Constructor kế thừa từ GenericRepository
        public PondRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Phương thức lấy thông tin Pond theo cấp độ
        public async Task<Pond> GetPondByLevelAsync(int level)
        {
            try
            {
                return await _context.Ponds
                    .FirstOrDefaultAsync(p => p.Level == level);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching pond by level", ex);
            }
        }

        // Phương thức lấy tất cả các Pond theo dung tích
        public async Task<IEnumerable<Pond>> GetPondsByCapacityAsync(int capacity)
        {
            try
            {
                return await _context.Ponds
                    .Where(p => p.Capacity == capacity)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching ponds by capacity", ex);
            }
        }
    }
}
