using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
