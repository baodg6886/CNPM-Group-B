
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IKoiFishService
    {
        // Lấy thông tin chi tiết của cá Koi dựa trên ID
        Task<KoiFish> GetKoiFishByIdAsync(int id);

        // Lấy danh sách tất cả cá Koi
        Task<IEnumerable<KoiFish>> GetAllKoiFishAsync();

        // Thêm một cá Koi mới
        Task AddKoiFishAsync(KoiFish koiFish);

        // Cập nhật thông tin cá Koi
        Task UpdateKoiFishAsync(KoiFish koiFish);

        // Xóa một cá Koi dựa trên ID
        Task DeleteKoiFishAsync(int id);

        // Tìm kiếm cá Koi theo tiêu chí (ví dụ: theo màu, giống, trạng thái)
        Task<IEnumerable<KoiFish>> SearchKoiFishAsync(
            string? color = null,
            string? breed = null,
            KoiStatus? status = null);

        // Tính giá trị trung bình của cá Koi theo giống hoặc trạng thái
        Task<float> CalculateAveragePriceByBreedAsync(string breed);

        // Kiểm tra cá Koi theo logic nghiệp vụ cụ thể (ví dụ: có hợp lệ để ghép giống hay không)
        Task<bool> ValidateBreedingAsync(int koiId1, int koiId2);
    }
}
