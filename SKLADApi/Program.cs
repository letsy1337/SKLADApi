using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;
using Microsoft.Extensions.Configuration;
using Humanizer.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<ProductsContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<OrdersContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<ReportsContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<CategoriesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<SupportMessagesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<SystemRolesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<UserRolesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<ReportTypesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<OrderDetailsContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<ImagesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<WarehousesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<UserTypesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<OrderStatusesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<DriverDeliversContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<DeliveryStatusesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<DeliveryPointsContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<DriverRoutesContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
builder.Services.AddDbContext<SuppliersContext>(opt =>
    opt.UseSqlServer("data source=Dmytro;initial catalog=SKLAD;trusted_connection=true;integrated security=True; TrustServerCertificate=True"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



