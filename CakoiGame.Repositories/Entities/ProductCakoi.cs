using System;
using System.Collections.Generic;

namespace CakoiGame.Repositories.Entities;

public partial class ProductCakoi
{
    public int IdproductCakoi { get; set; }

    public string NameCakoi { get; set; } = null!;

    public int SizeCakoi { get; set; }

    public int WeightCakoi { get; set; }

    public string SexCakoi { get; set; } = null!;

    public int MaGc { get; set; }

    public string OriginCakoi { get; set; } = null!;

    public decimal PriceCakoi { get; set; }

    public string? ImgCakoi { get; set; }
}
