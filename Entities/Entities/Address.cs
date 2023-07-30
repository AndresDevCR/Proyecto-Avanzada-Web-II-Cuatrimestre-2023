using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
