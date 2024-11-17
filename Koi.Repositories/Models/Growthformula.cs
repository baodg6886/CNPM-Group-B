using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Growthformula
{
    public int GrowthFormulaId { get; set; }

    public string Breed { get; set; } = null!;

    public int Age { get; set; }

    public float GrowthSpeed { get; set; }
}
