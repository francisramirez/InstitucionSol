

using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
 

namespace School.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IRepositoryBase<Department>
    {

        public DepartmentRepository(SchoolContext context) :base(context)
        {

        }
    }
}
