using DataAccessEF;
using DataAccessEF.UnitOfWork;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Accessing to connection string and adding DbContext EshopContext to the service container
builder.Services.AddDbContext<EshopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// add transient service for the IUnitOfWork interface and mapping it to the UnitOfWork class.
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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
