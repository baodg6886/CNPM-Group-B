
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IKoiFishServices
    {
        Task<Koifish> GetKoiFishByIdAsync(int id);
        Task<IEnumerable<Koifish>> GetAllKoiFishAsync();
        Task AddKoiFishAsync(Koifish koiFish);
        Task UpdateKoiFishAsync(Koifish koiFish);
        Task DeleteKoiFishAsync(int id);
        Task<IEnumerable<Koifish>> SearchKoiFishAsync(
            string? color = null,
            string? breed = null,
            string  status = null);


    }
}
