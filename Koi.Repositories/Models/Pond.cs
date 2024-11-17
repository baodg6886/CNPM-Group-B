using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Pond
{
    public int PondId { get; set; }

    public int Level { get; set; }

    public int Capacity { get; set; }

    public string Environment { get; set; } = null!;
}
