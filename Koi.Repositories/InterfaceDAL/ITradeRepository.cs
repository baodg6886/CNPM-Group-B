using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface ITradeRepository : IGenericRepository<Trade>
    {
        // Lấy tất cả các giao dịch với các thông tin liên quan (Seller, Buyer, Koi)
        Task<IEnumerable<Trade>> GetAllTradesAsync();

        // Lấy các giao dịch theo người mua hoặc người bán (UserId)
        Task<IEnumerable<Trade>> GetTradesByUserAsync(int userId);

        // Tìm kiếm giao dịch theo điều kiện (predicate)
        Task<IEnumerable<Trade>> FindTradesAsync(Func<Trade, bool> predicate);
     
    }
}
