using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? PrimaryPhoneNumber { get; set; }

    public string? SecondaryPhoneNumber { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    //public virtual ICollection<User> Users { get; set; } = new List<User>();
}
