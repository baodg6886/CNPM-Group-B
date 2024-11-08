using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public class BreedingFormula
    {
        public int BreedingFormulaID { get; set; }
        public required string FatherBreed { get; set; }
        public required string MotherBreed { get; set; }
        public float MutationRate { get; set; }
        public float Cost { get; set; }
    }
}
