using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Services.Services
{
    public class KoiFishServices : IKoiFishServices
    {
        private readonly IKoifishRepository _koiFishRepository;

        public KoiFishServices(IKoifishRepository koiFishRepository)
        {
            _koiFishRepository = koiFishRepository;
        }

        public async Task<Koifish> GetKoiFishByIdAsync(int id)
        {
            var koiFish = await _koiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");
            return koiFish;
        }

        public async Task<IEnumerable<Koifish>> GetAllKoiFishAsync()
        {
            return await _koiFishRepository.GetAllAsync();
        }

        public async Task AddKoiFishAsync(Koifish koiFish)
        {
            if (string.IsNullOrEmpty(koiFish.Name))
                throw new ArgumentException("Tên cá Koi không được để trống.");

            if (await IsDuplicateNameAsync(koiFish.Name))
                throw new ArgumentException("Tên cá Koi đã tồn tại.");

            await _koiFishRepository.AddAsync(koiFish);
        }

        private async Task<bool> IsDuplicateNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateKoiFishAsync(Koifish koiFish)
        {
            var existingKoi = await _koiFishRepository.GetByIdAsync(koiFish.KoiId);
            if (existingKoi == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");

            await _koiFishRepository.UpdateAsync(koiFish);
        }

        public async Task DeleteKoiFishAsync(int id)
        {
            var koiFish = await _koiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");

            await _koiFishRepository.DeleteAsync(id);
        }

        // Tìm kiếm cá Koi theo các tiêu chí: màu, giống, trạng thái
        public async Task<IEnumerable<Koifish>> SearchKoiFishAsync(string? color, string? breed, string? status)
        {         
            var allKoiFish = await _koiFishRepository.GetAllAsync(); 

            var filteredKoiFish = allKoiFish.Where(koi =>
                (string.IsNullOrEmpty(color) || koi.Color.Contains(color)) &&
                (string.IsNullOrEmpty(breed) || koi.Breed.Contains(breed)) &&
                (string.IsNullOrEmpty(status) || koi.Status == status)
            );

            // Trả về danh sách đã lọc
            return filteredKoiFish.ToList(); // Chuyển đổi lại về List trước khi trả về
        }
    }
}


