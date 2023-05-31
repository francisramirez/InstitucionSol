﻿

using School.Domain.Entities;
using School.Domain.Repository;
using System.Collections.Generic;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        List<Course> GetCoursesByDepartment(int departmentId);
    }
}
