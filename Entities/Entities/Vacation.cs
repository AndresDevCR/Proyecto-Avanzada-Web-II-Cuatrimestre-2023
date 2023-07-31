using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Vacation
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ReentryDate { get; set; }

    public string RequestStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // public virtual Employee Employee { get; set; } = null!;
}
