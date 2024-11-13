using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.Interface;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class GrowthFormualServices : IGrowthFormualServices
    {
        private readonly IGrowthFormulaRepository _growthFormulaRepository;

        public GrowthFormualServices(IGrowthFormulaRepository growthFormulaRepository)
        {
            _growthFormulaRepository = growthFormulaRepository;
        }

        // Sửa phương thức này
        public async Task<GrowthFormual> GetGrowthFormulaByIdAsync(int growthFormulaId)
        {
            var growthFormula = await _growthFormulaRepository.GetByIdAsync(growthFormulaId);
            if (growthFormula == null)
            {
                throw new KeyNotFoundException("Growth formula not found.");
            }

            return growthFormula;
        }

        public async Task<IEnumerable<GrowthFormual>> GetAllGrowthFormulasAsync()
        {
            return await _growthFormulaRepository.GetAllAsync();
        }

        public async Task AddGrowthFormulaAsync(GrowthFormual growthFormula)
        {
            // Kiểm tra nếu thông tin cần thiết hợp lệ
            if (growthFormula.GrowthSpeed <= 0)
            {
                throw new InvalidOperationException("Growth speed must be greater than 0.");
            }

            await _growthFormulaRepository.AddAsync(growthFormula);
        }

        public async Task UpdateGrowthFormulaAsync(GrowthFormual growthFormula)
        {
            var existingGrowthFormula = await _growthFormulaRepository.GetByIdAsync(growthFormula.GrowthFormulaID);
            if (existingGrowthFormula == null)
            {
                throw new KeyNotFoundException("Growth formula not found.");
            }

            existingGrowthFormula.Breed = growthFormula.Breed;
            existingGrowthFormula.Age = growthFormula.Age;
            existingGrowthFormula.GrowthSpeed = growthFormula.GrowthSpeed;

            await _growthFormulaRepository.UpdateAsync(existingGrowthFormula);
        }

        public async Task DeleteGrowthFormulaAsync(int growthFormulaId)
        {
            var growthFormula = await _growthFormulaRepository.GetByIdAsync(growthFormulaId);
            if (growthFormula == null)
            {
                throw new KeyNotFoundException("Growth formula not found.");
            }

            await _growthFormulaRepository.DeleteAsync(growthFormula);
        }
    }
}
