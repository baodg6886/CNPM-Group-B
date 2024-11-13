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
        Task<User> GetByUsernameAsync(string username); 
        Task<IEnumerable<User>> GetUsersWithBalanceAboveAsync(decimal amount);
        


        
        
        
    }

}
