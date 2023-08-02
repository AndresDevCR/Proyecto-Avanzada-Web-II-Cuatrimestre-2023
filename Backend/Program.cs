using Backend.Middlewares;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Connection String

builder.Services.AddDbContext<PrograContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");
Util.ConnectionString = connString;

#endregion

// Add services to the container.
builder.Services.AddScoped<IUserDal, UserDalImpl>();
builder.Services.AddScoped<IRoleDal, RoleDalImpl>();
builder.Services.AddScoped<IAddressDal, AddressDalImpl>();
builder.Services.AddScoped<IApplicationDal, ApplicationDalImpl>();
builder.Services.AddScoped<IClientDal, ClientDalImpl>();
builder.Services.AddScoped<ICompanyDal, CompanyDalImpl>();
builder.Services.AddScoped<IDepartmentDal, DepartmentDalImpl>();
builder.Services.AddScoped<IEmployeeDal, EmployeeDalImpl>();
builder.Services.AddScoped<IEnterpriseDAL, EnterpriseDALImpl>();
builder.Services.AddScoped<IHumanResourceDAL, HumanResourceDalImpl>();
builder.Services.AddScoped<IInventoryDAL, InventoryDalImpl>();
builder.Services.AddScoped<IInvoiceDAL, InvoiceDalImpl>();
builder.Services.AddScoped<ILocationDAL, LocationDalImpl>();
builder.Services.AddScoped<IPaymentDAL, PaymentDalImpl>();
builder.Services.AddScoped<IRoleHasPermissionDal, RoleHasPermissionDalImpl>();
builder.Services.AddScoped<ISupplierDal, SupplierDalImpl>();
builder.Services.AddScoped<IVacationDal, VacationDalImpl>();
builder.Services.AddScoped<IQuotationDal, QuotationDalImpl>();
builder.Services.AddScoped<IUserHasApplicationDal, UserHasApplicationDalImpl>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseMiddleware<GlobalRoutePrefixMiddleware>("/api/v1");
app.UsePathBase(new PathString("/api/v1"));
app.UseRouting();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePathBase(new PathString("/api/v1"));
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
