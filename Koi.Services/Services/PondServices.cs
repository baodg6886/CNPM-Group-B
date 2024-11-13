using Koi.Repositories.Models;
using Koi.Repositories.Interface;
using Koi.Services.InterfaceServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Services.Services
{
    public class PondServices : IPondServices
    {
        private readonly List<Pond> _ponds;  // Giả sử đang dùng List<Pond> làm cơ sở dữ liệu.

        public PondServices()
        {
            _ponds = new List<Pond>();  // Dữ liệu mẫu
        }

        // Lấy hồ cá theo ID
        public async Task<Pond> GetPondByIdAsync(int pondId)
        {
            var pond = _ponds.FirstOrDefault(p => p.PondID == pondId);
            return await Task.FromResult(pond);
        }

        // Lấy tất cả hồ cá
        public async Task<IEnumerable<Pond>> GetAllPondsAsync()
        {
            return await Task.FromResult(_ponds);
        }

        // Tạo hồ cá mới
        public async Task CreatePondAsync(Pond pond)
        {
            _ponds.Add(pond);
            await Task.CompletedTask;
        }

        // Cập nhật hồ cá
        public async Task UpdatePondAsync(Pond pond)
        {
            var existingPond = _ponds.FirstOrDefault(p => p.PondID == pond.PondID);
            if (existingPond != null)
            {
                existingPond.Level = pond.Level;
                existingPond.Capacity = pond.Capacity;
                existingPond.Environment = pond.Environment;
            }
            await Task.CompletedTask;
        }

        // Xóa hồ cá
        public async Task DeletePondAsync(int pondId)
        {
            var pond = _ponds.FirstOrDefault(p => p.PondID == pondId);
            if (pond != null)
            {
                _ponds.Remove(pond);
            }
            await Task.CompletedTask;
        }

        // Lấy dung lượng còn lại của hồ cá
        public async Task<int> GetAvailableCapacityAsync(int pondId)
        {
            var pond = _ponds.FirstOrDefault(p => p.PondID == pondId);
            if (pond != null)
            {
                return await Task.FromResult(pond.Capacity - (pond.Level)); // Giả sử Level là số lượng cá hiện tại
            }
            return 0;
        }
    }
}
