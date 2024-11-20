using System;
using System.Collections.Generic;

namespace CakoiGame.Repositories.Entities;

public partial class QlUser
{
    public int IdqlUser { get; set; }

    public string UsernameUser { get; set; } = null!;

    public string? EmailUser { get; set; }

    public string PasswordUser { get; set; } = null!;

    public string? PhoneUser { get; set; }

    public string? AccessUser { get; set; }
}
