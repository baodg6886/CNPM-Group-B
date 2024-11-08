using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Models
{
    public class GrowthFormulaRepository : GenericRepository<GrowthFormual>, IGrowthFormulaRepository
    {
        private readonly KoiFishGameContext _context;
        public GrowthFormulaRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Nếu cần các phương thức tùy chỉnh, bạn có thể bổ sung thêm ở đây
        public async Task<IEnumerable<GrowthFormual>> GetByBreedAsync(string breed)
        {
            return await _context.GrowthFormulas
                .Where(g => g.Breed == breed)
                .ToListAsync();
        }
    }
}
