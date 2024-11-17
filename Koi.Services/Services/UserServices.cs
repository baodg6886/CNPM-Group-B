using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Đăng ký người dùng mới
        public async Task<User> RegisterUserAsync(string username, string password)
        {
            // Kiểm tra điều kiện đăng ký
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            return await _userRepository.RegisterUserAsync(username, password);
        }

        // Lấy thông tin người dùng theo tên đăng nhập
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        // Nạp tiền vào tài khoản người dùng
        public async Task DepositAsync(int userId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount should be greater than zero.");
            }

            await _userRepository.DepositAsync(userId, amount);
        }

        // Kiểm tra thông tin đăng nhập
        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            return await _userRepository.ValidateUserCredentialsAsync(username, password);
        }
    }
}
