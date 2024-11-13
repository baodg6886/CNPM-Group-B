using System;
using System.Collections.Generic;
using Koi.Repositories.Models;


namespace Koi.Services.InterfaceServices
{
    public interface IPondServices
    {
        Task<Pond> GetPondByIdAsync(int pondId);
        Task<IEnumerable<Pond>> GetAllPondsAsync();
        Task CreatePondAsync(Pond pond);
        Task UpdatePondAsync(Pond pond);
        Task DeletePondAsync(int pondId);
        Task<int> GetAvailableCapacityAsync(int pondId);
    }
}
