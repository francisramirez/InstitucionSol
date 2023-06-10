

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
             
        public override void Update(Department entity)
        {
            try
            {
                Department departmentToUpdate = this.GetEntity(entity.DepartmentID);

                departmentToUpdate.DepartmentID = entity.DepartmentID;
                departmentToUpdate.ModifyDate = entity.ModifyDate;
                departmentToUpdate.Name = entity.Name;
                departmentToUpdate.StartDate = entity.StartDate;
                departmentToUpdate.UserMod = entity.UserMod;
                departmentToUpdate.Administrator = entity.Administrator;
                departmentToUpdate.Budget = entity.Budget;

                this.context.Departments.Update(departmentToUpdate);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el departamento", ex.ToString());
            }
        }
        public override void Remove(Department entity)
        {
            try
            {
                Department departmentToRemove= this.GetEntity(entity.DepartmentID);

                departmentToRemove.Deleted = entity.Deleted;
                departmentToRemove.DeletedDate = entity.DeletedDate;
                departmentToRemove.UserDeleted = entity.UserDeleted;

                this.context.Departments.Update(departmentToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error eliminando el departamento", ex.ToString());
            }
        }
        public DepartmentModel GetDepartmentById(int id)
        {
            DepartmentModel departmentModel = new DepartmentModel();


            try
            {
                Department department = this.GetEntity(id);

                departmentModel.Administrator = department.Administrator;
                departmentModel.DepartmentId = department.DepartmentID;
                departmentModel.StartDate = department.StartDate;
                departmentModel.Name = department.Name;


            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el department", ex.ToString());
            }

            return departmentModel;
        }
        public List<DepartmentModel> GetDepartments()
        {

            List<DepartmentModel> departments = new List<DepartmentModel>();

            try
            {
                departments = this.context.Departments
                                 .Where(cd => !cd.Deleted)
                                 .Select(de => new DepartmentModel()
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
