using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Phone
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Number { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
