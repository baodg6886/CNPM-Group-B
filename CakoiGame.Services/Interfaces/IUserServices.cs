
using CakoiGame.Repositories.Entities;

namespace CakoiGame.Services.Interfaces
{
    public interface IUserSvc
    {
        Task<List<QlUser>> GetAllUsersAsync();
        Task<QlUser> GetAllUserByIdAsync(int id);
        Task EditUserAsync(QlUser qlUser);
        Task CreateUserAsync(QlUser qlUser);
        Task DeleteUserAsync(int id);
    }
}
