using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Koi.Repositories.Base;

namespace Koi.Repositories.Models
{
    public interface IGrowthFormulaRepository : IGenericRepository<GrowthFormual>
    {
        // Thêm các phương thức tùy chỉnh cho GrowthFormula nếu cần
        Task<IEnumerable<GrowthFormual>> GetByBreedAsync(string breed); // Lấy công thức theo giống cá
    }
}
