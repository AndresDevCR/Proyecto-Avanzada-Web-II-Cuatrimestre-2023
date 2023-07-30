using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Position
{
    public int Id { get; set; }

    public string PositionName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
