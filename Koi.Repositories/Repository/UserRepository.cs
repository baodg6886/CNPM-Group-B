using System.Threading.Tasks;
using System.Linq;
using Koi.Repositories.Models;
using Koi.Repositories.InterfaceDAL;
using Microsoft.EntityFrameworkCore;
using Koi.Repositories.Base;

namespace Koi.Repositories.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly KoiFishGameContext _context;

        // Constructor kế thừa từ GenericRepository
        public UserRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        // Tìm người dùng theo tên đăng nhập
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
        }

        // Đăng ký người dùng mới
        public async Task<User> RegisterUserAsync(string username, string password)
        {
            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await GetByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Tạo người dùng mới
            var newUser = new User
            {
                Username = username,
                Password = password,  // Lưu mật khẩu đã mã hóa (nên mã hóa mật khẩu trước khi lưu)
                Balance = 0,  // Có thể khởi tạo số dư ban đầu nếu cần
                UserRole = "Player" // Vai trò mặc định cho người dùng
            };

            await AddAsync(newUser); // Sử dụng phương thức từ GenericRepository
            return newUser;
        }

        // Nạp tiền vào tài khoản người dùng
        public async Task DepositAsync(int userId, decimal amount)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Balance += amount;
            await UpdateAsync(user);  // Sử dụng phương thức từ GenericRepository để cập nhật người dùng
        }

        // Kiểm tra đăng nhập (so sánh tên đăng nhập và mật khẩu)
        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            var user = await GetByUsernameAsync(username);
            if (user != null && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
