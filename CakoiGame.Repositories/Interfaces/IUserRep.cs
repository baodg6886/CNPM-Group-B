using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;

namespace CakoiGame.Repositories.Interfaces
{
    public interface IUserRep
    {
        Task<List<QlUser>> GetAllUsersAsync();
        Task<QlUser> GetAllUserByIdAsync(int id);
        Task EditUserAsync(QlUser qlUser);
        Task CreateUserAsync(QlUser qlUser);
        Task DeleteUserAsync(int id);
    }
}
