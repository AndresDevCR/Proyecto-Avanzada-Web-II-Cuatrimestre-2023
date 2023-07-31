using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class PrograContext : DbContext
{
    public PrograContext()
    {
        var optionBuilder = new DbContextOptionsBuilder<PrograContext>();
        optionBuilder.UseSqlServer(Util.ConnectionString);
    }

    public PrograContext(DbContextOptions<PrograContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Enterprise> Enterprises { get; set; }

    public virtual DbSet<HumanResource> HumanResources { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleHasPermission> RoleHasPermissions { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserHasApplication> UserHasApplications { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Util.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__address__3213E83F6932B275");

            entity.ToTable("address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_primary");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_on");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__applicat__3213E83F20C3D033");

            entity.ToTable("application");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("display_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client__3213E83F0321D778");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ClientName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("client_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EnterpriseId).HasColumnName("enterprise_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Enterprise).WithMany(p => p.Clients)
            //     .HasForeignKey(d => d.EnterpriseId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK__client__enterpri__540C7B00");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company__3213E83FB386FBB2");

            entity.ToTable("company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PrimaryPhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("primary_phone_number");
            entity.Property(e => e.SecondaryPhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("secondary_phone_number");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F3C8CE103");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("department_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F53CE57B4");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableVacationQuantity).HasColumnName("available_vacation_quantity");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.EnrollmentDate)
                .HasColumnType("date")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.MonthlySalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monthly_salary");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__depart__6FB49575");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__positi__6EC0713C");
        });

        modelBuilder.Entity<Enterprise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__enterpri__3213E83F46F1C233");

            entity.ToTable("enterprise");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EnterpriseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("enterprise_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<HumanResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__human_re__3213E83F983AC581");

            entity.ToTable("human_resource");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.EntryDate)
                .HasColumnType("date")
                .HasColumnName("entry_date");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.RestDays)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rest_days");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Schedule)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("schedule");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.VacationDays)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vacation_days");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__inventor__3213E83F59FECB9C");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableQuantity).HasColumnName("available_quantity");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EntryDate)
                .HasColumnType("date")
                .HasColumnName("entry_date");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoice__3213E83F5E9CB071");

            entity.ToTable("invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DollarValue)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("dollar_value");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("date")
                .HasColumnName("expiration_date");
            entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");
            entity.Property(e => e.IssueDate)
                .HasColumnType("date")
                .HasColumnName("issue_date");
            entity.Property(e => e.QuotationId).HasColumnName("quotation_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TotalColon)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_colon");
            entity.Property(e => e.TotalDollar)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_dollar");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Quotation).WithMany(p => p.Invoices)
            //     .HasForeignKey(d => d.QuotationId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK__invoice__quotati__6166761E");

            // entity.HasOne(d => d.Supplier).WithMany(p => p.Invoices)
            //     .HasForeignKey(d => d.SupplierId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK__invoice__supplie__625A9A57");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__location__3213E83F22C5B309");

            entity.ToTable("location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("building");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment__3213E83FF7DFAA77");

            entity.ToTable("payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BiweeklySalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("biweekly_salary");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DailySalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("daily_salary");
            entity.Property(e => e.DeductionTotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("deduction_total");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ExtraTime)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("extra_time");
            entity.Property(e => e.ExtraTimeTotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("extra_time_total");
            entity.Property(e => e.ExtraTimeValue)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("extra_time_value");
            entity.Property(e => e.GrossPayment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("gross_payment");
            entity.Property(e => e.GrossPaymentSocialDeduction)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("gross_payment_social_deduction");
            entity.Property(e => e.HourRate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("hour_rate");
            entity.Property(e => e.InsPayroll)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ins_payroll");
            entity.Property(e => e.MedicalLeaveDays)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("medical_leave_days");
            entity.Property(e => e.NetPayment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("net_payment");
            entity.Property(e => e.NetPaymentDollar)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("net_payment_dollar");
            entity.Property(e => e.NotPayedLeaveDays)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("not_payed_leave_days");
            entity.Property(e => e.PaymentAdvance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("payment_advance");
            entity.Property(e => e.Subsidy)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subsidy");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payment__employe__793DFFAF");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83FBF7C8BAB");

            entity.ToTable("permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_on");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__phone__3213E83FC84A0ADD");

            entity.ToTable("phone");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_primary");
            entity.Property(e => e.Phone1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Type)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_on");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            // entity.HasOne(d => d.User).WithMany(p => p.Phones)
            //     .HasForeignKey(d => d.UserId)
            //     .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83F0221AD45");

            entity.ToTable("position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("position_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__profile__3213E83FA9B4A434");

            entity.ToTable("profile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("image_url");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__quotatio__3213E83FA8CB02C1");

            entity.ToTable("quotation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EInvoiceCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("e_invoice_code");
            entity.Property(e => e.IssueDate)
                .HasColumnType("date")
                .HasColumnName("issue_date");
            entity.Property(e => e.PoDate)
                .HasColumnType("date")
                .HasColumnName("po_date");
            entity.Property(e => e.PoNumber).HasColumnName("po_number");
            entity.Property(e => e.QuoteTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("quote_title");
            entity.Property(e => e.TotalPayment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_payment");
            entity.Property(e => e.TotalPaymentDollar)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_payment_dollar");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Client).WithMany(p => p.Quotations)
            //     .HasForeignKey(d => d.ClientId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK__quotation__clien__58D1301D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F5A87427C");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RoleHasPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId }).HasName("role_perm_pk");

            entity.ToTable("role_has_permission");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.RoleHasPermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("fk_permission");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83F90BA682D");

            entity.ToTable("supplier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("supplier_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FE51FB8B9");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E616487D1811D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyStartDate)
                .HasColumnType("date")
                .HasColumnName("company_start_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_active");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PasswordResetCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_reset_code");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Company).WithMany(p => p.Users)
            //     .HasForeignKey(d => d.CompanyId)
            //     .HasConstraintName("fk_company");
            //
            // entity.HasOne(d => d.Profile).WithMany(p => p.Users)
            //     .HasForeignKey(d => d.ProfileId)
            //     .HasConstraintName("fk_profile");
            //
            // entity.HasOne(d => d.Role).WithMany(p => p.Users)
            //     .HasForeignKey(d => d.RoleId)
            //     .HasConstraintName("fk_role");
        });

        modelBuilder.Entity<UserHasApplication>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ApplicationId }).HasName("user_app_pk");

            entity.ToTable("user_has_applications");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");

            entity.HasOne(d => d.Application).WithMany(p => p.UserHasApplications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("fk_application");
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vacation__3213E83F6A480C96");

            entity.ToTable("vacation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ReentryDate)
                .HasColumnType("date")
                .HasColumnName("reentry_date");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_status");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            // entity.HasOne(d => d.Employee).WithMany(p => p.Vacations)
            //     .HasForeignKey(d => d.EmployeeId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FK__vacation__employ__74794A92");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}