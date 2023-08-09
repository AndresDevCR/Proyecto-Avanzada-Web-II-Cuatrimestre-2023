using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public int PositionId { get; set; }

    public int DepartmentId { get; set; }

    public decimal MonthlySalary { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int AvailableVacationQuantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

   // public virtual Department Department { get; set; } = null!;

   // public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

  //  public virtual Position Position { get; set; } = null!;

   // public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
}
