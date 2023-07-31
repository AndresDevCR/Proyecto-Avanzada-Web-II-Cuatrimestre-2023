using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
