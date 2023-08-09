using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Application
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

   // public virtual ICollection<UserHasApplication> UserHasApplications { get; set; } = new List<UserHasApplication>();
}
