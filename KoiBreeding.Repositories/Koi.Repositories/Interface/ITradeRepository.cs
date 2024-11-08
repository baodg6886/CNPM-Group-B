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
        Task<IEnumerable<Trade>> GetTransactionsByUserIdAsync(int userId);  // Lấy giao dịch theo người dùng
        Task<Trade> GetTransactionByKoiIdAsync(int koiId);  // Lấy giao dịch theo cá Koi
    }


}
