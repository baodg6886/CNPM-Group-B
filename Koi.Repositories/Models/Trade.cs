using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public class Trade
    {
        public int TradeID { get; set; }
        public required User Seller { get; set; }
        public required User Buyer { get; set; }
        public required KoiFish KoiFishes { get; set; }
        public float Price { get; set; }
        public DateTime Time { get; set; }
    }
}
