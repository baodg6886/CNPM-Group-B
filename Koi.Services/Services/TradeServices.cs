using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return await _tradeRepository.GetAllTradesAsync();
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserAsync(int userId)
        {
            return await _tradeRepository.GetTradesByUserAsync(userId);
        }

        public async Task AddTradeAsync(int sellerId, int buyerId, int koiId, float price)
        {
            var trade = new Trade
            {
                SellerId = sellerId,
                BuyerId = buyerId,
                KoiId = koiId,
                Price = price,
                Time = DateTime.Now
            };
            await _tradeRepository.AddAsync(trade);
        }

        public async Task UpdateTradeAsync(Trade trade)
        {
            await _tradeRepository.UpdateAsync(trade);
        }

        public async Task DeleteTradeAsync(int tradeId)
        {
            await _tradeRepository.DeleteAsync(tradeId);
        }

        public async Task<IEnumerable<Trade>> FindTradesAsync(Func<Trade, bool> predicate)
        {
            return await _tradeRepository.FindTradesAsync(predicate);
        }
    }
}