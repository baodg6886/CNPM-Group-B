using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;

namespace CakoiGame.Repositories.Interfaces
{
    public interface IProductCakoiRepository
    {
        Task<List<ProductCakoi>> GetAllAsync();
        Task<ProductCakoi> GetByIdAsync(int id);
        Task AddAsync(ProductCakoi productCakoi);
        Task UpdateAsync(ProductCakoi productCakoi);
        Task DeleteAsync(int id);
        Task<List<ProductCakoi>> SearchByNameAsync(string searchQuery);
    }
}
