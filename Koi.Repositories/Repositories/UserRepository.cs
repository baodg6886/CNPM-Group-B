using Koi.Repositories.Base;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Koi.Repositories.Repositories
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly KoiFishGameContext _context;

        public UserRepository(KoiFishGameContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<User> GetByIdAsync(int UserID)
        {
            User? user = await _context.Users.FindAsync(UserID);
            return user;
        }
        public async Task<User> GetByUsernameAsync(string username) => await _context.Users
                                 .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<IEnumerable<User>> GetUsersWithBalanceAboveAsync(decimal amount)
        {
            
            return await _context.Users
                                 .Where(u => u.Balance > amount)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

