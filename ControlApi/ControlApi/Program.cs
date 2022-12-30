using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Logic;
using ControlAPI.Repository;
using ControlAPI.Repository.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ControlDbContext>(
    options => {
        //options.UseSqlServer("ConnectionString");
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
    });
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(Program));
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
