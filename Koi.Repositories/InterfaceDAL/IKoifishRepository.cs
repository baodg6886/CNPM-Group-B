using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    public interface IKoifishRepository : IGenericRepository<Koifish>
    {
        // Tìm cá Koi theo giống
        Task<IEnumerable<Koifish>> GetKoifishByBreedAsync(string breed);

        // Tìm cá Koi theo trạng thái (Breeding, Growing, ForSale)
        Task<IEnumerable<Koifish>> GetKoifishByStatusAsync(string status);

        // Tìm cá Koi theo tên
        Task<Koifish> GetKoifishByNameAsync(string name);
    

        // Lọc cá Koi theo giá (Price)
        Task<IEnumerable<Koifish>> GetKoifishByPriceRangeAsync(float minPrice, float maxPrice);

        // Lọc cá Koi theo tuổi
        Task<IEnumerable<Koifish>> GetKoifishByAgeAsync(int minAge, int maxAge);
        
    }
}
