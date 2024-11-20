using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;
using CakoiGame.Repositories.Interfaces;
using CakoiGame.Services.Interfaces;

namespace CakoiGame.Services.Services
{
  
        public class ProductCakoiService : IProductCakoiService
        {
            private readonly IProductCakoiRepository _productCakoiRepository;

            public ProductCakoiService(IProductCakoiRepository productCakoiRepository)
            {
                _productCakoiRepository = productCakoiRepository;
            }

            public async Task<List<ProductCakoi>> GetAllProductsAsync()
            {
                return await _productCakoiRepository.GetAllAsync();
            }

            public async Task<List<ProductCakoi>> SearchProductsAsync(string searchQuery)
            {
                return await _productCakoiRepository.SearchByNameAsync(searchQuery);
            }
        }
    

}
