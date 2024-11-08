using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Models
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly KoiFishGameContext _context;
        public ItemRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Triển khai phương thức tùy chỉnh cho Item
        public async Task<IEnumerable<Item>> GetItemsByTypeAsync(ItemType itemType)
        {
            return await _context.Items
                                 .Where(i => i.Type == itemType)
                                 .ToListAsync();
        }
    }
}
