using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;

using Koi.Services.InterfaceServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Services.Services
{
    public class PondServices : IPondServices
    {
        private readonly IPondRepository _pondRepository;

        // Constructor để inject PondRepository
        public PondServices(IPondRepository pondRepository)
        {
            _pondRepository = pondRepository;
        }

        // Lấy tất cả các hồ cá
        public async Task<IEnumerable<Pond>> GetAllPondsAsync()
        {
            try
            {
                return await _pondRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching all ponds", ex);
            }
        }

        // Lấy hồ cá theo ID
        public async Task<Pond> GetPondByIdAsync(int id)
        {
            try
            {
                return await _pondRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching pond by ID {id}", ex);
            }
        }

        // Lấy hồ cá theo cấp độ
        public async Task<Pond> GetPondByLevelAsync(int level)
        {
            try
            {
                return await _pondRepository.GetPondByLevelAsync(level);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching pond by level {level}", ex);
            }
        }

        // Lấy tất cả hồ cá theo dung tích
        public async Task<IEnumerable<Pond>> GetPondsByCapacityAsync(int capacity)
        {
            try
            {
                return await _pondRepository.GetPondsByCapacityAsync(capacity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching ponds by capacity {capacity}", ex);
            }
        }

        // Thêm hồ cá mới
        public async Task AddPondAsync(Pond pond)
        {
            try
            {
                await _pondRepository.AddAsync(pond);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding new pond", ex);
            }
        }

        // Cập nhật hồ cá
        public async Task UpdatePondAsync(Pond pond)
        {
            try
            {
                await _pondRepository.UpdateAsync(pond);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating pond", ex);
            }
        }

        // Xóa hồ cá
        public async Task DeletePondAsync(int id)
        {
            try
            {
                await _pondRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting pond with ID {id}", ex);
            }
        }
    }
}
