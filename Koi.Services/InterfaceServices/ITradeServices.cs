using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface ITradeServices
    {
        Task<Trade> GetTradeByIdAsync(int tradeId);
        Task<IEnumerable<Trade>> GetAllTradesAsync();
        Task<IEnumerable<Trade>> GetTradesByUserIdAsync(int userId);
        Task AddTradeAsync(Trade trade);
        Task DeleteTradeAsync(int tradeId);
    }
}
