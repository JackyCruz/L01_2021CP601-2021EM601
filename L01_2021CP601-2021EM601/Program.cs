using Microsoft.EntityFrameworkCore;
using L01_2021CP601_2021EM601.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Inyección por dependencia del string de conexion al contexto
builder.Services.AddDbContext<restauranteDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("clientesDbConnection")
        )
    );
builder.Services.AddControllers();
//Inyección por dependencia del string de conexion al contexto
builder.Services.AddDbContext<restauranteDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("pedidosDbConnection")
        )
    );
builder.Services.AddControllers();
//Inyección por dependencia del string de conexion al contexto
builder.Services.AddDbContext<restauranteDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("motoristasDbConnection")
        )
    );

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
