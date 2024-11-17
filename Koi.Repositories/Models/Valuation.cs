using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public class Valuation
    {
        public int ID { get; set; }
        public required string Breed { get; set; }
        public int Age { get; set; }
        public float Size { get; set; }
        public float Weight { get; set; }
        public GenderKoi Gender { get; set; }
        public bool Mutation { get; set; }
        public float Value { get; set; }

    }
}
