using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories
{
    public class BreedingRepository : GenericRepository<Breeding>, IBreedingRepository
    {
        private readonly KoiFishGameContext _context;

        // Constructor để inject KoiGameContext vào BreedingRepository
        public BreedingRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Phương thức để lấy danh sách quá trình sinh sản theo trạng thái
        public async Task<IEnumerable<Breeding>> GetBreedingByStatusAsync(BreedingStatus status)
        {
            // Lọc quá trình sinh sản theo trạng thái
            return await _context.Breedings
                                 .Where(b => b.Status == status)
                                 .Include(b => b.Father)   // Bao gồm thông tin về cá bố
                                 .Include(b => b.Mother)   // Bao gồm thông tin về cá mẹ
                                 .Include(b => b.Offspring) // Bao gồm danh sách cá con
                                 .ToListAsync();
        }

        // Phương thức để lấy một quá trình sinh sản theo ID
        public async Task<Breeding> GetBreedingByIdAsync(int breedingId)
        {
            // Tìm quá trình sinh sản theo BreedingID
            return await _context.Breedings
                                 .Include(b => b.Father)
                                 .Include(b => b.Mother)
                                 .Include(b => b.Offspring)
                                 .FirstOrDefaultAsync(b => b.BreedingID == breedingId);
        }

        // Phương thức để thêm một quá trình sinh sản mới
        public async Task AddBreedingAsync(Breeding breeding)
        {
            // Thêm quá trình sinh sản mới vào DbSet
            await _context.Breedings.AddAsync(breeding);
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Phương thức để cập nhật trạng thái quá trình sinh sản
        public async Task UpdateBreedingStatusAsync(int breedingId, BreedingStatus newStatus)
        {
            var breeding = await _context.Breedings
                                          .FirstOrDefaultAsync(b => b.BreedingID == breedingId);
            if (breeding != null)
            {
                breeding.Status = newStatus;
                await _context.SaveChangesAsync(); // Lưu thay đổi
            }
        }

        // Phương thức để lấy tất cả các quá trình sinh sản
        public async Task<IEnumerable<Breeding>> GetAllBreedingAsync()
        {
            return await _context.Breedings
                                 .Include(b => b.Father)
                                 .Include(b => b.Mother)
                                 .Include(b => b.Offspring)
                                 .ToListAsync();
        }

        public Task<IEnumerable<Breeding>> GetOngoingBreedingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Breeding> GetBreedingByParentsAsync(int fatherid, int motherid)
        {
            throw new NotImplementedException();
        }
    }
}
