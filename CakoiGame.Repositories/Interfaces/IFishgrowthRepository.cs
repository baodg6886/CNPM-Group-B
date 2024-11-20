using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;

namespace CakoiGame.Repositories.Interfaces
{
    public interface IFishgrowthRepository
    {
        Task<List<Fishgrowth>> GetAllAsync();
        Task<Fishgrowth> GetByIdAsync(int id);
        Task AddAsync(Fishgrowth fishgrowth);
        Task UpdateAsync(Fishgrowth fishgrowth);
        Task DeleteAsync(int id);
    }
}
