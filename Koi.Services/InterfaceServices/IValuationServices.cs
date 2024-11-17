using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Models;

namespace Koi.Services.InterfaceServices
{
    public interface IValuationServices
    {
        Task<Valuation> GetValuationByIdAsync(int valuationId);
        Task<IEnumerable<Valuation>> GetAllValuationsAsync();
        Task AddValuationAsync(Valuation valuation);
        Task UpdateValuationAsync(Valuation valuation);
        Task DeleteValuationAsync(int valuationId);
    }
}
