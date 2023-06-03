using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Models;
using System.Collections.Generic;

namespace School.Infrastructure.Interfaces
{
    public interface  IDepartmentRepository : IRepositoryBase<Department>
    {
        List<DepartmentModel> GetDepartments();
    }
}
