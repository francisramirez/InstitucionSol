using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Context;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro de dependencia base de de datos //
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


// Repositories //
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddTransient<ICourseRepository, CourseRepository>();



// Registros de app services //





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
