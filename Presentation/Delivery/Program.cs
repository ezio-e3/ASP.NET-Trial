using Delivery.Application.Riders;
using Delivery.Domain;
using Delivery.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDeliveryContext,DeliveryContext>(a =>
{
    a.UseSqlServer(builder.Configuration.GetConnectionString("Delivery"));
});

builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(GetRider).Assembly));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
