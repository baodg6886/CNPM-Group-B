using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakoiGame.Repositories.Entities;


namespace CakoiGame.Services.Interfaces
{
    public interface IFishgrowthServices
    {
        Task<List<Fishgrowth>> GetAllFishgrowthsAsync();
        Task<Fishgrowth> GetFishgrowthByIdAsync(int id);
        Task AddFishgrowthAsync(Fishgrowth fishgrowth);
        Task UpdateFishgrowthAsync(Fishgrowth fishgrowth);
        Task DeleteFishgrowthAsync(int id);
    }
}
