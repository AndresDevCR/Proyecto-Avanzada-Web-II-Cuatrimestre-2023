using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Enterprise
{
    public int Id { get; set; }

    public string EnterpriseName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
