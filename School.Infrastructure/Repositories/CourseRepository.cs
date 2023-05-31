

using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Core;
using School.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public List<Course> GetCoursesByDepartment(int departmentId)
        {
            throw new System.NotImplementedException();
        }

         
    }
}

