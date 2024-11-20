using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;


namespace CakoiGame.Services.Interfaces
{
    public interface IProductCakoiService
    {
        Task<List<ProductCakoi>> GetAllProductsAsync();
        Task<List<ProductCakoi>> SearchProductsAsync(string searchQuery);
    }
}