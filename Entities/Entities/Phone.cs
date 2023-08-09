using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Phone
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Phone1 { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    //public virtual User User { get; set; } = null!;
}
