using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IItemServices
    {
        Task<Item> GetItemByIdAsync(int itemId);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int itemId);
        Task<IEnumerable<Item>> GetItemsByTypeAsync(ItemType itemType);
    }
}
