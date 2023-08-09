using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Profile
{
    public int Id { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? Birthdate { get; set; }
}
