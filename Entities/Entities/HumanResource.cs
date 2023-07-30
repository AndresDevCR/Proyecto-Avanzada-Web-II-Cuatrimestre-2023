using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class HumanResource
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public int Salary { get; set; }

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Schedule { get; set; } = null!;

    public string RestDays { get; set; } = null!;

    public string VacationDays { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
