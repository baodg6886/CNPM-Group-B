using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class Trade
{
    public int TradeId { get; set; }

    public int SellerId { get; set; }

    public int BuyerId { get; set; }

    public int KoiId { get; set; }

    public float Price { get; set; }

    public DateTime Time { get; set; }

    public virtual User Buyer { get; set; } = null!;

    public virtual Koifish Koi { get; set; } = null!;

    public virtual User Seller { get; set; } = null!;
}
