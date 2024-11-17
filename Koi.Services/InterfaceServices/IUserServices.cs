using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(string username, string password);
        Task<User> GetUserByUsernameAsync(string username);
        Task DepositAsync(int userId, decimal amount);
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
    }
}
