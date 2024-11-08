using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;

namespace Koi.Repositories.Models
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        // Thêm các phương thức tùy chỉnh cho Item nếu cần
        Task<IEnumerable<Item>> GetItemsByTypeAsync(ItemType itemType); // Lấy các Item theo loại
    }
}
