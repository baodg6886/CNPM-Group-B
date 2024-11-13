using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface 
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task DeleteAsync(Item item);
        Task<IEnumerable<Item>> GetByTypeAsync(ItemType itemType);

        Task<IEnumerable<Item>> GetItemsByTypeAsync(ItemType itemType); 
    }
}
