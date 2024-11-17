using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Valuation
{
    public int Id { get; set; }

    public string Breed { get; set; } = null!;

    public int Age { get; set; }

    public float Size { get; set; }

    public float Weight { get; set; }

    public string Gender { get; set; } = null!;

    public bool Mutation { get; set; }

    public float Value { get; set; }
}
