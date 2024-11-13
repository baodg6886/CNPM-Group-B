using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface ITradeRepository : IGenericRepository<Trade>
    {
        Task<IEnumerable<Trade>> GetTransactionsByUserIdAsync(int userId);  
        Task<Trade> GetTransactionByKoiIdAsync(int koiId);  
        Task DeleteAsync(Trade trade);
        Task<IEnumerable<Trade>> GetByUserIdAsync(int userId);
    }


}
