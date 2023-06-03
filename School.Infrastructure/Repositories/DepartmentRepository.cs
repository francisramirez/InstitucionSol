

using Microsoft.Extensions.Logging;
using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<DepartmentRepository> logger;

        public DepartmentRepository(SchoolContext context,
                                    ILogger<DepartmentRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Add(Department entity)
        {

            if (this.Exists(dep => dep.Name == entity.Name))
            {
                throw new DepartmentException("Departamento existe.");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public List<DepartmentModel> GetDepartments()
        {
            
            List<DepartmentModel> departments = new List<DepartmentModel>();

            try
            {
                departments = this.context.Departments.Select(de => new DepartmentModel()
                {
                    Administrator = de.Administrator,
                    DepartmentId = de.DepartmentID,
                    Name = de.Name,
                    StartDate = de.StartDate
                }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los departamentos", ex.ToString());
            }

            return departments;
        }
    }
}
