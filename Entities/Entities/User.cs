using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PasswordResetCode { get; set; }

    public bool? IsActive { get; set; }

    public int? ProfileId { get; set; }

    public int? CompanyId { get; set; }

    public DateTime? CompanyStartDate { get; set; }

    public int? RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

    public virtual Profile? Profile { get; set; }

    public virtual Role? Role { get; set; }
}
