using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.InterfaceDAL
{
    
        public interface IUserRepository : IGenericRepository<User>
        {
            // Phương thức tìm kiếm người dùng theo tên đăng nhập
            Task<User> GetByUsernameAsync(string username);

            // Phương thức đăng ký người dùng mới
            Task<User> RegisterUserAsync(string username, string password);

            // Phương thức nạp tiền vào tài khoản người dùng
            Task DepositAsync(int userId, decimal amount);

            // Phương thức kiểm tra đăng nhập
            Task<bool> ValidateUserCredentialsAsync(string username, string password);
        }
    
}
