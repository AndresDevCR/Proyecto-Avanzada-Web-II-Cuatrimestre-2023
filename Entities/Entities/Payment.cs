using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public decimal BiweeklySalary { get; set; }

    public decimal DailySalary { get; set; }

    public decimal Subsidy { get; set; }

    public decimal HourRate { get; set; }

    public decimal ExtraTimeValue { get; set; }

    public decimal ExtraTime { get; set; }

    public decimal ExtraTimeTotal { get; set; }

    public decimal MedicalLeaveDays { get; set; }

    public decimal NotPayedLeaveDays { get; set; }

    public decimal GrossPayment { get; set; }

    public decimal? GrossPaymentSocialDeduction { get; set; }

    public decimal PaymentAdvance { get; set; }

    public decimal DeductionTotal { get; set; }

    public decimal NetPayment { get; set; }

    public decimal NetPaymentDollar { get; set; }

    public decimal InsPayroll { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
