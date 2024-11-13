using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Koi.Repositories.Models
{
    public partial class KoiFishGameContext(DbContextOptions<KoiFishGameContext> options) : DbContext(options)
    {
            public DbSet<User> Users { get; set; }
            public DbSet<KoiFish> Kois { get; set; }
            public DbSet<Pond> Ponds { get; set; }
            public DbSet<Breeding> Breedings { get; set; }
            public DbSet<Item> Items { get; set; }
            public DbSet<Trade> Transactions { get; set; }
            public DbSet<BreedingFormula> BreedingFormulas { get; set; }
            public DbSet<GrowthFormual> GrowthFormulas { get; set; }
            public DbSet<Valuation> Valuations { get; set; }
        
    }
}
