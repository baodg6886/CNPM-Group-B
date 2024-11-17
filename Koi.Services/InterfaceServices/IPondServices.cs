using System;
using System.Collections.Generic;
using Koi.Repositories.Models;


namespace Koi.Services.InterfaceServices
{
    public interface IPondServices
    {
        // Lấy tất cả các hồ cá
        Task<IEnumerable<Pond>> GetAllPondsAsync();

        // Lấy thông tin hồ cá theo ID
        Task<Pond> GetPondByIdAsync(int id);

        // Lấy hồ cá theo cấp độ
        Task<Pond> GetPondByLevelAsync(int level);

        // Lấy tất cả hồ cá theo dung tích
        Task<IEnumerable<Pond>> GetPondsByCapacityAsync(int capacity);

        // Thêm hồ cá mới
        Task AddPondAsync(Pond pond);

        // Cập nhật hồ cá
        Task UpdatePondAsync(Pond pond);

        // Xóa hồ cá
        Task DeletePondAsync(int id);
    }
}
