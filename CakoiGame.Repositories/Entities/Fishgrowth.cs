using System;
using System.Collections.Generic;

namespace CakoiGame.Repositories.Entities;

public partial class Fishgrowth
{
    public int Id { get; set; }

    public string? AgeRange { get; set; }

    public string? GrowthLevel { get; set; }

    public int? MaxGrowthCm { get; set; }
}
