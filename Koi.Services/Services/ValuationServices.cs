using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Koi.Services.Services
{
    public class ValuationServices : IValuationServices
    {
        private readonly IValuationRepository _valuationRepository;

        public ValuationServices(IValuationRepository valuationRepository)
        {
            _valuationRepository = valuationRepository;
        }

        public async Task<Valuation> GetValuationByIdAsync(int valuationId)
        {
            var valuation = await _valuationRepository.GetByIdAsync(valuationId);
            if (valuation == null)
            {
                throw new KeyNotFoundException("Valuation not found.");
            }

            return valuation;
        }

        public async Task<IEnumerable<Valuation>> GetAllValuationsAsync()
        {
            return await _valuationRepository.GetAllAsync();
        }

        public async Task AddValuationAsync(Valuation valuation)
        {
            // Kiểm tra nếu thông tin cần thiết hợp lệ
            if (valuation.Value <= 0)
            {
                throw new InvalidOperationException("Valuation value must be greater than 0.");
            }

            await _valuationRepository.AddAsync(valuation);
        }

        public async Task UpdateValuationAsync(Valuation valuation)
        {
            var existingValuation = await _valuationRepository.GetByIdAsync(valuation.Id);
            if (existingValuation == null)
            {
                throw new KeyNotFoundException("Valuation not found.");
            }

            // Cập nhật thông tin Valuation
            existingValuation.Breed = valuation.Breed;
            existingValuation.Age = valuation.Age;
            existingValuation.Size = valuation.Size;
            existingValuation.Weight = valuation.Weight;
            existingValuation.Gender = valuation.Gender;
            existingValuation.Mutation = valuation.Mutation;
            existingValuation.Value = valuation.Value;

            await _valuationRepository.UpdateAsync(existingValuation);
        }

        public async Task DeleteValuationAsync(int valuationId)
        {
            var valuation = await _valuationRepository.GetByIdAsync(valuationId);
            if (valuation == null)
            {
                throw new KeyNotFoundException("Valuation not found.");
            }

            await _valuationRepository.DeleteAsync(valuationId);
        }
    }
}
