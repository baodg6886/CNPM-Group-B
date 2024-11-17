using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi.Repositories.InterfaceDAL;
using Koi.Repositories.Models;
using Koi.Services.InterfaceServices;

namespace Koi.Services.Services
{
    public class BreedingFormulaServices : IBreedingFormulaServices 
    {
        private readonly IBreedingFormulaRepository _breedingFormulaRepository;

        public BreedingFormulaServices(IBreedingFormulaRepository breedingFormulaRepository)
        {
            _breedingFormulaRepository = breedingFormulaRepository;
        }

        public async Task<Breedingformula> GetBreedingFormulaByIdAsync(int breedingFormulaId)
        {
            var breedingFormula = await _breedingFormulaRepository.GetByIdAsync(breedingFormulaId);
            if (breedingFormula == null)
            {
                throw new KeyNotFoundException("Breeding formula not found.");
            }

            return breedingFormula;
        }

        public async Task<IEnumerable<Breedingformula>> GetAllBreedingFormulasAsync()
        {
            return await _breedingFormulaRepository.GetAllAsync();
        }

        public async Task AddBreedingFormulaAsync(Breedingformula breedingFormula)
        {
            // Kiểm tra nếu thông tin cần thiết hợp lệ
            if (breedingFormula.MutationRate < 0 || breedingFormula.MutationRate > 1)
            {
                throw new InvalidOperationException("Mutation rate must be between 0 and 1.");
            }

            await _breedingFormulaRepository.AddAsync(breedingFormula);
        }

        public async Task UpdateBreedingFormulaAsync(Breedingformula breedingFormula)
        {
            var existingBreedingFormula = await _breedingFormulaRepository.GetByIdAsync(breedingFormula.BreedingFormulaId);
            if (existingBreedingFormula == null)
            {
                throw new KeyNotFoundException("Breeding formula not found.");
            }

            existingBreedingFormula.FatherBreed = breedingFormula.FatherBreed;
            existingBreedingFormula.MotherBreed = breedingFormula.MotherBreed;
            existingBreedingFormula.MutationRate = breedingFormula.MutationRate;
            existingBreedingFormula.Cost = breedingFormula.Cost;

            await _breedingFormulaRepository.UpdateAsync(existingBreedingFormula);
        }

        public async Task DeleteBreedingFormulaAsync(int breedingFormulaId)
        {
            var breedingFormula = await _breedingFormulaRepository.GetByIdAsync(breedingFormulaId);
            if (breedingFormula == null)
            {
                throw new KeyNotFoundException("Breeding formula not found.");
            }

            await _breedingFormulaRepository.DeleteAsync(breedingFormula);
        }
    }
}
