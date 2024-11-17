using System;
using System.Collections.Generic;

namespace Koi.Repositories.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? Balance { get; set; }

    public string UserRole { get; set; } = null!;

    public virtual ICollection<Trade> TradeBuyers { get; set; } = new List<Trade>();

    public virtual ICollection<Trade> TradeSellers { get; set; } = new List<Trade>();
}
