

using Microsoft.Extensions.DependencyInjection;
using School.Application.Contract;
using School.Application.Service;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;


namespace School.IOC.Dependencies
{
    public static class CourseDependency
    {
        public static void AddCourseDependency(this IServiceCollection services) 
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();

        }
    }
}
