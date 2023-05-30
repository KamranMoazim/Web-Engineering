using System;
using System.Collections.Generic;

namespace lec14.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string TagLine { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime JoinedDate { get; set; }
}
