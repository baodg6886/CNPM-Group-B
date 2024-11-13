using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Koi.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly KoiFishGameContext _context;

        // Constructor để inject KoiGameContext vào UserRepository
        public UserRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Phương thức lấy người dùng theo tên đăng nhập
        public async Task<User> GetByIdAsync(int UserID)
        {
            return await _context.Users.FindAsync(UserID);
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            // Sử dụng FirstOrDefaultAsync để tìm người dùng theo tên đăng nhập
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Username == username);
        }

        // Phương thức lấy danh sách người dùng có số dư tài khoản lớn hơn giá trị truyền vào
        public async Task<IEnumerable<User>> GetUsersWithBalanceAboveAsync(decimal amount)
        {
            // Lọc người dùng có số dư tài khoản lớn hơn amount
            return await _context.Users
                                 .Where(u => u.Balance > amount)
                                 .ToListAsync();
        }

        // Phương thức lấy tất cả người dùng (tuỳ chọn nếu cần)

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Lấy tất cả người dùng từ bảng Users
            return await _context.Users.ToListAsync();
        }
    }
}

