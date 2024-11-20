using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;
using CakoiGame.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CakoiGame.Repositories.Repositories
{
    

    
        public class ProductCakoiRepository : IProductCakoiRepository
        {
            private readonly CakoiContext _context;

            public ProductCakoiRepository(CakoiContext context)
            {
                _context = context;
            }

            // Lấy tất cả các sản phẩm Cakoi
            public async Task<List<ProductCakoi>> GetAllAsync()
            {
                return await _context.ProductCakois.ToListAsync();
            }

            // Lấy một sản phẩm Cakoi theo ID
            public async Task<ProductCakoi> GetByIdAsync(int id)
            {
                return await _context.ProductCakois.FindAsync(id);
            }

            // Thêm một sản phẩm Cakoi
            public async Task AddAsync(ProductCakoi productCakoi)
            {
                await _context.ProductCakois.AddAsync(productCakoi);
                await _context.SaveChangesAsync();
            }

            // Cập nhật một sản phẩm Cakoi
            public async Task UpdateAsync(ProductCakoi productCakoi)
            {
                _context.ProductCakois.Update(productCakoi);
                await _context.SaveChangesAsync();
            }

            // Xóa một sản phẩm Cakoi
            public async Task DeleteAsync(int id)
            {
                var productCakoi = await _context.ProductCakois.FindAsync(id);
                if (productCakoi != null)
                {
                    _context.ProductCakois.Remove(productCakoi);
                    await _context.SaveChangesAsync();
                }
            }

            public Task<List<ProductCakoi>> SearchByNameAsync(string searchQuery)
            {
                throw new NotImplementedException();
            }
        }
    

}
