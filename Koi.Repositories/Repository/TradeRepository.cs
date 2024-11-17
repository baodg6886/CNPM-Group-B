using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Repository
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        private readonly KoiFishGameContext _context;

        // Constructor kế thừa từ GenericRepository, không cần thêm _context nữa
        public TradeRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lấy tất cả các giao dịch
        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            try
            {
                return await _context.Trades
                    .Include(t => t.Seller)
                    .Include(t => t.Buyer)
                    .Include(t => t.Koi)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching trades", ex);
            }
        }

        // Lấy các giao dịch theo người mua hoặc người bán (UserId)
        public async Task<IEnumerable<Trade>> GetTradesByUserAsync(int userId)
        {
            try
            {
                return await _context.Trades
                    .Where(t => t.SellerId == userId || t.BuyerId == userId)
                    .Include(t => t.Seller)
                    .Include(t => t.Buyer)
                    .Include(t => t.Koi)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching trades by user", ex);
            }
        }

        // Tìm kiếm giao dịch theo điều kiện (predicate)
        public async Task<IEnumerable<Trade>> FindTradesAsync(Func<Trade, bool> predicate)
        {
            try
            {
                return await Task.FromResult(_context.Trades.Where(predicate).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while finding trades", ex);
            }
        }
    }
}
