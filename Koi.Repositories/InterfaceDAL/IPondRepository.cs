using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IPondRepository : IGenericRepository<Pond>
    {
        // Lấy thông tin Pond theo cấp độ
        Task<Pond> GetPondByLevelAsync(int level);

        // Lấy tất cả các Pond theo dung tích
        Task<IEnumerable<Pond>> GetPondsByCapacityAsync(int capacity);
    }
}
