
using Microsoft.Extensions.DependencyInjection;
using School.Application.Contract;
using School.Application.Service;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;

namespace School.IOC.Dependencies
{
    public static class DepartmentDependency
    {
        public static void AddDepartmentDependency(this IServiceCollection services) 
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartamentService, DepartamentService>();
        }
    }
}
