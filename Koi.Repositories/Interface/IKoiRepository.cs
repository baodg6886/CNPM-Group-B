using Koi.Repositories.Base;
using Koi.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Koi.Repositories
{
    public interface IKoiRepository : IGenericRepository<KoiFish>
    {
        Task<KoiFish?> GetKoiByNameAsync(string name);  
        Task<IEnumerable<KoiFish>> GetKoisByAgeAsync(int age);  
        Task<IEnumerable<KoiFish>> GetKoisByNameAsync(string name);
        Task<IEnumerable<KoiFish>> GetKoisByColorAsync(string color);
        Task<IEnumerable<KoiFish>> GetKoisByWeightAsync(double minWeight);
    }
}
