using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IPondRepository : IGenericRepository<Pond>
    {
        Task<IEnumerable<Pond>> GetPondsByUserIdAsync(int userId);  
        Task<Pond> GetPondByIdAsync(int id);  
    }

}
