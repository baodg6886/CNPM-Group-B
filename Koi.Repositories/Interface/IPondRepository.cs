using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koi.Repositories.Base;
using Koi.Repositories.Models;

namespace Koi.Repositories.Interface
{
    public interface IPondRepository : IGenericRepository<Pond>
    {  
        Task<IEnumerable<Pond>> GetAllPagingAsync(string search, int offset, int limit);     
        Task<IEnumerable<Pond>> GetPondsByLevelAsync(int level);
    }
}
