using CakoiGame.Repositories.Entities;
using CakoiGame.Repositories.Interfaces;
using CakoiGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakoiGame.Services
{
    public class UserSvc : IUserSvc
    {
        private readonly IUserRep _userRep;

        public UserSvc(IUserRep userRep)
        {
            _userRep = userRep;
        }

        public async Task<List<QlUser>> GetAllUsersAsync()
        {
            return await _userRep.GetAllUsersAsync();
        }

        public async Task<QlUser> GetAllUserByIdAsync(int itemid)
        {
            return await _userRep.GetAllUserByIdAsync(itemid);
        }

        public async Task CreateUserAsync(QlUser product)
        {
            await _userRep.CreateUserAsync(product);
        }

        public async Task EditUserAsync(QlUser product)
        {
            await _userRep.EditUserAsync(product);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRep.DeleteUserAsync(id);
        }
    }
}
