using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IBreedingRepository : IGenericRepository<Breeding>
    {
        Task<IEnumerable<Breeding>> GetOngoingBreedingsAsync();  // Lấy các quá trình sinh sản đang diễn ra
        Task<Breeding> GetBreedingByParentsAsync(int fatherid, int motherid);  // Lấy quá trình sinh sản theo cặp cá bố mẹ
    }

}
