using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int EnterpriseId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

   //public virtual Enterprise Enterprise { get; set; } = null!;

   // public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
}
