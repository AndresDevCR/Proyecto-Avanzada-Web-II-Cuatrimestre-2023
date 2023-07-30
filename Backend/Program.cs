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
builder.Services.AddScoped<IEnterpriseDAL, EnterpriseDALImpl>();
builder.Services.AddScoped<IHumanResourceDAL, HumanResourceDalImpl>();
builder.Services.AddScoped<IInventoryDAL, InventoryDalImpl>();
builder.Services.AddScoped<IInvoiceDAL, InvoiceDalImpl>();
builder.Services.AddScoped<ILocationDAL, LocationDalImpl>();
builder.Services.AddScoped<IPaymentDAL, PaymentDalImpl>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();