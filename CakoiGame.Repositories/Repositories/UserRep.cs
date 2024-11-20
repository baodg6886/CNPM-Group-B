using CakoiGame.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CakoiGame.Repositories.Interfaces;


namespace CakoiGame.Repositories.Repositories
{
    public class UserRep : IUserRep
    {
        private readonly CakoiContext _context;

        public UserRep(CakoiContext context)
        {
            _context = context;
        }

        public async Task<List<QlUser>> GetAllUsersAsync()
        {
            return await _context.QlUsers.ToListAsync();
        }

        public async Task<QlUser> GetAllUserByIdAsync(int itemid)
        {
          
            return await _context.QlUsers.FirstOrDefaultAsync(x => x.IdqlUser == itemid);
        }

        public async Task CreateUserAsync(QlUser qlUser)
        {
            _context.QlUsers.Add(qlUser);
            await _context.SaveChangesAsync();
        }

        public async Task EditUserAsync(QlUser qlUser)
        {
            _context.QlUsers.Update(qlUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int itemid)
        {
            var customer = await _context.QlUsers.FirstOrDefaultAsync(x => x.IdqlUser == itemid);
            if (customer != null)
            {
                _context.QlUsers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
