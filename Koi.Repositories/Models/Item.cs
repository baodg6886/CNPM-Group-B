using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public float Price { get; set; }
}
