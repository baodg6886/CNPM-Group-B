using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterUserAsync(User user);
        Task<bool> AuthenticateUserAsync(string username, string password);
        Task UpdateUserBalanceAsync(int userId, decimal amount);
        Task ChangeUserPasswordAsync(int userId, string newPassword);
    }
}
