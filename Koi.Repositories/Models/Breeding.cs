using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Breeding
{
    public int BreedingId { get; set; }

    public string Type { get; set; } = null!;

    public int? FatherId { get; set; }

    public int? MotherId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Koifish? Father { get; set; }

    public virtual Koifish? Mother { get; set; }
  
}
