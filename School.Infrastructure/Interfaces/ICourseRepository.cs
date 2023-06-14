using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Models;
using System.Collections.Generic;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        List<CursoModel> GetCoursesByDepartment(int departmentId);
        List<CursoModel> GetCourses();
    }
}
