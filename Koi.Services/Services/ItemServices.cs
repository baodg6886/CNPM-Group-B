using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    internal class ItemServices :IItemServices 
    {
        private readonly IItemRepository _itemRepository;

        public ItemServices(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            return item;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task AddItemAsync(Item item)
        {
            // Kiểm tra thông tin item hợp lệ
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new InvalidOperationException("Item name cannot be empty.");
            }

            await _itemRepository.AddAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            var existingItem = await _itemRepository.GetByIdAsync(item.ItemID);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            await _itemRepository.UpdateAsync(item);
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            await _itemRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<Item>> GetItemsByTypeAsync(ItemType itemType)
        {
            return await _itemRepository.GetByTypeAsync(itemType);
        }
    }
}

