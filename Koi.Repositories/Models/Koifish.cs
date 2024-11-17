using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Koifish
{
    public int KoiId { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int Age { get; set; }

    public float Size { get; set; }

    public float Weight { get; set; }

    public string Gender { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public float Price { get; set; }

    public string Status { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Breeding> BreedingFathers { get; set; } = new List<Breeding>();

    public virtual ICollection<Breeding> BreedingMothers { get; set; } = new List<Breeding>();

    public virtual ICollection<Trade> Trades { get; set; } = new List<Trade>();
}
