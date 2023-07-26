using Microsoft.EntityFrameworkCore;
using School.Application.Contract;
using School.Application.Service;
using School.Infrastructure.Context;
using School.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro de dependencia base de de datos //
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


//my Dependencies
builder.Services.AddCourseDependency();
builder.Services.AddDepartmentDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//app.UseCors();

app.MapControllers();

app.Run();
