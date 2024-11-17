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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly KoiFishGameContext _context;

        public ItemRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lọc Item theo loại
        public async Task<IEnumerable<Item>> GetItemsByTypeAsync(string type)
        {
            return await _context.Items
                .Where(i => i.Type.Contains(type))
                .ToListAsync();
        }

        // Lọc Item theo giá
        public async Task<IEnumerable<Item>> GetItemsByPriceRangeAsync(float minPrice, float maxPrice)
        {
            return await _context.Items
                .Where(i => i.Price >= minPrice && i.Price <= maxPrice)
                .ToListAsync();
        }

        // Tìm Item theo tên
        public async Task<Item> GetItemByNameAsync(string name)
        {
            return await _context.Items
                .FirstOrDefaultAsync(i => i.Name == name);
        }
    }
}
