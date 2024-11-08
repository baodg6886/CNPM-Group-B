using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public enum ItemType
    {
        Food,
        Medicine

    }
    public class Item
    {
        public int ItemID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ItemType Type { get; set; }
        public float Price { get; set; }

    }
}
