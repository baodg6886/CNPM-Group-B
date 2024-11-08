using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Repositories
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        private readonly KoiFishGameContext _context;

        public TradeRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lấy danh sách giao dịch của người mua
        public async Task<IEnumerable<Trade>> GetTradesByBuyerIdAsync(int buyerId)
        {
            return await _context.Transactions
                                 .Where(t => t.Buyer.UserID == buyerId)
                                 .ToListAsync();
        }

        // Lấy danh sách giao dịch của người bán
        public async Task<IEnumerable<Trade>> GetTradesBySellerIdAsync(int sellerId)
        {
            return await _context.Transactions
                                 .Where(t => t.Seller.UserID == sellerId)
                                 .ToListAsync();
        }

        public Task<Trade> GetTransactionByKoiIdAsync(int koiId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trade>> GetTransactionsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
