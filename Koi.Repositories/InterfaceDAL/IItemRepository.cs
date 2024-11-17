using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        // Lọc Item theo loại
        Task<IEnumerable<Item>> GetItemsByTypeAsync(string type);

        // Lọc Item theo giá
        Task<IEnumerable<Item>> GetItemsByPriceRangeAsync(float minPrice, float maxPrice);

        // Tìm Item theo tên
        Task<Item> GetItemByNameAsync(string name);
        Task DeleteAsync(Item item);
    }
}
