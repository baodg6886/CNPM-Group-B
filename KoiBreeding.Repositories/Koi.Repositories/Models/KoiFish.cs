using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
  
    public class KoiFish  
    {
        public int KoiID { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public int Age { get; set; }
        public float Size { get; set; }
        public float Weight { get; set; }
        public GenderKoi Gender { get; set; }
        public required string Breed { get; set; }
        public required string Origin { get; set; }
        public float Price { get; set; }
        public KoiStatus Status { get; set; }
        public string? Color { get; internal set; }
     
    } 
    public enum GenderKoi
    {
        Male,
        Female
    }
    public enum KoiStatus
    {
        Breeding,
        Growing,
        ForSale

    }
}
