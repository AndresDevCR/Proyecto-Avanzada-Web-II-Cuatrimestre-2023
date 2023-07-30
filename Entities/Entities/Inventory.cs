using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Inventory
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int AvailableQuantity { get; set; }

    public string Description { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
