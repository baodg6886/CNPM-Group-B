using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Models;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;

namespace Koi.Repositories
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        private readonly KoiFishGameContext _context;

        public TradeRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lấy giao dịch theo người bán
        public async Task<IEnumerable<Trade>> GetTradesBySellerAsync(int sellerId)
        {
            return await _context.Transactions
                .Where(t => t.Seller.UserID == sellerId)
                .Include(t => t.Seller)
                .Include(t => t.Buyer)
                .Include(t => t.KoiFishes)
                .ToListAsync();
        }

        // Lấy giao dịch theo người mua
        public async Task<IEnumerable<Trade>> GetTradesByBuyerAsync(int buyerId)
        {
            return await _context.Transactions
                .Where(t => t.Buyer.UserID == buyerId)
                .Include(t => t.Seller)
                .Include(t => t.Buyer)
                .Include(t => t.KoiFishes)
                .ToListAsync();
        }

        // Lấy giao dịch theo khoảng giá
        public async Task<IEnumerable<Trade>> GetTradesByPriceRangeAsync(float minPrice, float maxPrice)
        {
            return await _context.Transactions
                .Where(t => t.Price >= minPrice && t.Price <= maxPrice)
                .Include(t => t.Seller)
                .Include(t => t.Buyer)
                .Include(t => t.KoiFishes)
                .ToListAsync();
        }

        // Lấy giao dịch theo khoảng thời gian
        public async Task<IEnumerable<Trade>> GetTradesByTimeRangeAsync(DateTime startTime, DateTime endTime)
        {
            return await _context.Transactions
                .Where(t => t.Time >= startTime && t.Time <= endTime)
                .Include(t => t.Seller)
                .Include(t => t.Buyer)
                .Include(t => t.KoiFishes)
                .ToListAsync();
        }

        public Task<IEnumerable<Trade>> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Trade trade)
        {
            throw new NotImplementedException();
        }
    }
}
