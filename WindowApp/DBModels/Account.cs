using System;
using System.Collections.Generic;

namespace WindowApp.DBModels;

public partial class Account
{
    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? Pesel { get; set; }

    public decimal? Budget { get; set; }
}
