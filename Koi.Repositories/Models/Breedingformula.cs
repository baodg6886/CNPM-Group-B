using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Breedingformula
{
    public int BreedingFormulaId { get; set; }

    public string FatherBreed { get; set; } = null!;

    public string MotherBreed { get; set; } = null!;

    public float MutationRate { get; set; }

    public float Cost { get; set; }
}
