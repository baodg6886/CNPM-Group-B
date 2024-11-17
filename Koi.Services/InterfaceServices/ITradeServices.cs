using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> GetAllTradesAsync();
        Task<IEnumerable<Trade>> GetTradesByUserAsync(int userId);
        Task AddTradeAsync(int sellerId, int buyerId, int koiId, float price);
        Task UpdateTradeAsync(Trade trade);
        Task DeleteTradeAsync(int tradeId);
        Task<IEnumerable<Trade>> FindTradesAsync(Func<Trade, bool> predicate);
    }
}
