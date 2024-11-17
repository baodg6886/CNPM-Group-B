using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public class Pond
    {       
        public int PondID { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public required string Environment { get; set; }

    }
}
