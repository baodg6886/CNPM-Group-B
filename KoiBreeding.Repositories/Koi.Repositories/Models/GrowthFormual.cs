using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public class GrowthFormual
    {
        public int GrowthFormulaID { get; set; }
        public required string Breed { get; set; }
        public int Age { get; set; }
        public float GrowthSpeed { get; set; }
    }
}
