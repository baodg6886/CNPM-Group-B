using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public enum BreedingType
    {
        Manual,
        Automatic
    }

    public enum BreedingStatus
    {
        InProgress,
        Hatched,
        Completed
    }

 

    public class Breeding
    {
        public int BreedingID { get; set; }
        public BreedingType Type { get; set; }
        public required KoiFish Father { get; set; }
        public required KoiFish Mother { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BreedingStatus Status { get; set; }
        public required List<KoiFish> Offspring { get; set; }
        
    }
}