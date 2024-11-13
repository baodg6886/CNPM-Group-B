
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IKoiFishService
    {
        Task<KoiFish> GetKoiFishByIdAsync(int id);
        Task<IEnumerable<KoiFish>> GetAllKoiFishAsync();
        Task AddKoiFishAsync(KoiFish koiFish);
        Task UpdateKoiFishAsync(KoiFish koiFish);
        Task DeleteKoiFishAsync(int id);
        Task<IEnumerable<KoiFish>> SearchKoiFishAsync(
            string? color = null,
            string? breed = null,
            KoiStatus? status = null);
        Task<float> CalculateAveragePriceByBreedAsync(string breed);
        Task<bool> ValidateBreedingAsync(int koiId1, int koiId2);
    }
}
