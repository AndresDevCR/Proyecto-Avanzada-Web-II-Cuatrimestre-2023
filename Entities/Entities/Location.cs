using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Building { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
