using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class TradeServices : ITradeServices 
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeServices(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task<Trade> GetTradeByIdAsync(int tradeId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId);
            if (trade == null)
            {
                throw new KeyNotFoundException("Trade not found.");
            }

            return trade;
        }

        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return await _tradeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(int userId)
        {
            return await _tradeRepository.GetByUserIdAsync(userId);
        }

        public async Task AddTradeAsync(Trade trade)
        {
            // Kiểm tra nếu các thông tin cần thiết hợp lệ
            if (trade.Price <= 0)
            {
                throw new InvalidOperationException("Price must be greater than 0.");
            }

            await _tradeRepository.AddAsync(trade);
        }

        public async Task DeleteTradeAsync(int tradeId)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId);
            if (trade == null)
            {
                throw new KeyNotFoundException("Trade not found.");
            }

            await _tradeRepository.DeleteAsync(trade);
        }
    }
}
