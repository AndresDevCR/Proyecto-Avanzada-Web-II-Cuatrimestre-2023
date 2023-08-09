using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public int QuotationId { get; set; }

    public int SupplierId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int InvoiceNumber { get; set; }

    public decimal DollarValue { get; set; }

    public decimal TotalColon { get; set; }

    public decimal TotalDollar { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

   // public virtual Quotation Quotation { get; set; } = null!;

   // public virtual Supplier Supplier { get; set; } = null!;
}
