using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Quotation
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public decimal TotalPayment { get; set; }

    public decimal TotalPaymentDollar { get; set; }

    public string EInvoiceCode { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public int PoNumber { get; set; }

    public DateTime PoDate { get; set; }

    public string Description { get; set; } = null!;

    public string QuoteTitle { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
