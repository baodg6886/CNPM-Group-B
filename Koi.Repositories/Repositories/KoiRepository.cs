using Koi.Repositories.Base;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories
{
    public class KoiRepository : GenericRepository<KoiFish>, IKoiRepository
    {
        private readonly KoiFishGameContext _context;

        public KoiRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Lấy cá Koi theo ID
        public async Task<KoiFish?> GetKoiByIdAsync(int id)
        {
            return await _context.Kois
                                 .FirstOrDefaultAsync(k => k.KoiID == id);
        }

        // Lấy tất cả cá Koi
        public async Task<IEnumerable<KoiFish>> GetAllKoisAsync()
        {
            return await _context.Kois.ToListAsync();
        }

        // Thêm cá Koi mới
        public async Task AddKoiAsync(KoiFish koi)
        {
            await _context.Kois.AddAsync(koi);
            await _context.SaveChangesAsync();
        }

        // Cập nhật cá Koi
        public async Task UpdateKoiAsync(KoiFish koi)
        {
            _context.Kois.Update(koi);
            await _context.SaveChangesAsync();
        }

        // Xóa cá Koi
        public async Task DeleteKoiAsync(int id)
        {
            var koi = await _context.Kois.FirstOrDefaultAsync(k => k.KoiID == id);
            if (koi != null)
            {
                _context.Kois.Remove(koi);
                await _context.SaveChangesAsync();
            }
        }

        // Lấy cá Koi theo tên
        public async Task<IEnumerable<KoiFish>> GetKoisByNameAsync(string name)
        {
            return await _context.Kois
                                 .Where(k => k.Name.Contains(name))
                                 .ToListAsync();
        }

        // Lấy cá Koi theo màu sắc
        public async Task<IEnumerable<KoiFish>> GetKoisByColorAsync(string color)
        {
            return await _context.Kois
                                 .Where(k => k.Color.Contains(color))
                                 .ToListAsync();
        }

        // Lấy các cá Koi có trọng lượng lớn hơn giá trị nhất định
        public async Task<IEnumerable<KoiFish>> GetKoisByWeightAsync(double minWeight)
        {
            return await _context.Kois
                                 .Where(k => k.Weight >= minWeight)
                                 .ToListAsync();
        }

        public Task<KoiFish?> GetKoiByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<KoiFish>> GetKoisByAgeAsync(int age)
        {
            throw new NotImplementedException();
        }
    }
}
