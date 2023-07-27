using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int InvoiceNumber { get; set; }

    public int OrderNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
