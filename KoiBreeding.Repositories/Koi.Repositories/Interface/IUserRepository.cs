using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        new Task<User> GetByIdAsync(int UserID);
        Task<User> GetByUsernameAsync(string username);  // Tìm kiếm người dùng theo tên đăng nhập
        Task<IEnumerable<User>> GetUsersWithBalanceAboveAsync(decimal amount);// Lấy người dùng có số dư tài khoản lớn hơn một số tiền nhất định
        


        
        
        
    }

}
