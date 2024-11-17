using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface ITradeRepository : IGenericRepository<Trade>
    {
        Task<IEnumerable<Trade>> GetTradesBySellerAsync(int sellerId);
        Task<IEnumerable<Trade>> GetTradesByBuyerAsync(int buyerId);
        Task<IEnumerable<Trade>> GetTradesByPriceRangeAsync(float minPrice, float maxPrice);
        Task<IEnumerable<Trade>> GetTradesByTimeRangeAsync(DateTime startTime, DateTime endTime);
        Task<IEnumerable<Trade>> GetByUserIdAsync(int userId);
        Task DeleteAsync(Trade trade);
    }
}
