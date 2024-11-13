using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Services.Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _koiFishRepository;

        public KoiFishService(IKoiFishRepository koiFishRepository)
        {
            _koiFishRepository = koiFishRepository;
        }

        public async Task<KoiFish> GetKoiFishByIdAsync(int id)
        {
            var koiFish = await _koiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");
            return koiFish;
        }

        public async Task<IEnumerable<KoiFish>> GetAllKoiFishAsync()
        {
            return await _koiFishRepository.GetAllAsync();
        }

        public async Task AddKoiFishAsync(KoiFish koiFish)
        {
            // Logic kiểm tra trước khi thêm
            if (string.IsNullOrEmpty(koiFish.Name))
                throw new ArgumentException("Tên cá Koi không được để trống.");

            if (await IsDuplicateNameAsync(koiFish.Name))
                throw new ArgumentException("Tên cá Koi đã tồn tại.");

            await _koiFishRepository.AddAsync(koiFish);
        }

        public async Task UpdateKoiFishAsync(KoiFish koiFish)
        {
            var existingKoi = await _koiFishRepository.GetByIdAsync(koiFish.KoiID);
            if (existingKoi == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");

            // Logic cập nhật
            await _koiFishRepository.UpdateAsync(koiFish);
        }

        public async Task DeleteKoiFishAsync(int id)
        {
            var koiFish = await _koiFishRepository.GetByIdAsync(id);
            if (koiFish == null)
                throw new KeyNotFoundException("Cá Koi không tồn tại.");

            await _koiFishRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<KoiFish>> SearchKoiFishAsync(string? color, string? breed, KoiStatus? status)
        {
            var allKoiFish = await _koiFishRepository.GetAllAsync();

            // Lọc cá Koi theo tiêu chí
            return allKoiFish.Where(koi =>
                (string.IsNullOrEmpty(color) || koi.Color == color) &&
                (string.IsNullOrEmpty(breed) || koi.Breed == breed) &&
                (!status.HasValue || koi.Status == status)
            );
        }

        public async Task<float> CalculateAveragePriceByBreedAsync(string breed)
        {
            var allKoiFish = await _koiFishRepository.GetAllAsync();
            var filteredKoi = allKoiFish.Where(koi => koi.Breed == breed);

            if (!filteredKoi.Any())
                throw new ArgumentException($"Không có cá Koi nào thuộc giống '{breed}'.");

            return filteredKoi.Average(koi => koi.Price);
        }

        public async Task<bool> ValidateBreedingAsync(int koiId1, int koiId2)
        {
            var koi1 = await _koiFishRepository.GetByIdAsync(koiId1);
            var koi2 = await _koiFishRepository.GetByIdAsync(koiId2);

            if (koi1 == null || koi2 == null)
                throw new KeyNotFoundException("Một trong hai cá Koi không tồn tại.");

            if (koi1.Gender == koi2.Gender)
                return false; // Không thể ghép đôi cùng giới tính

            if (koi1.Status != KoiStatus.Breeding || koi2.Status != KoiStatus.Breeding)
                return false; // Cả hai cá Koi phải ở trạng thái "Breeding"

            return true;
        }

        // Phương thức phụ trợ
        private async Task<bool> IsDuplicateNameAsync(string name)
        {
            var allKoiFish = await _koiFishRepository.GetAllAsync();
            return allKoiFish.Any(koi => koi.Name == name);
        }
    }
}
