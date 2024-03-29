﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;
using School.Infrastructure.Extentions;
namespace School.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ILogger<CourseRepository> logger;
        private readonly SchoolContext context;

        public CourseRepository(ILogger<CourseRepository> logger,
                                SchoolContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }
        public override void Add(Course entity)
        {

            if (this.Exists(cd => cd.Title == entity.Title))
                throw new CourseDataException("El curso ya existe.");

            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Course entity)
        {
            try
            {
                Course courseToUpdate = base.GetEntity(entity.CourseID);

                if (courseToUpdate is null)
                    throw new CourseDataException("El curso no existe.");


                //entity.GetType().GetProperties().ToList().ForEach(cd =>
                //{

                //    var propertyValue = cd.GetValue(entity);

                //    courseToUpdate.GetType()
                //                      .GetProperty(cd.Name)
                //                      .SetValue(courseToUpdate,
                //                                propertyValue,
                //                                null);
                //});


                courseToUpdate.Credits = entity.Credits;
                courseToUpdate.DepartmentID = entity.DepartmentID;
                courseToUpdate.ModifyDate = DateTime.Now;
                courseToUpdate.Title = entity.Title;
                courseToUpdate.UserMod = entity.UserMod;

                base.Update(courseToUpdate);
                base.SaveChanges();

            }
            catch (CourseDataException cdex)
            {
                throw new CourseDataException(cdex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el curso", ex.ToString());
            }
        }
        public override void Remove(Course entity)
        {
            try
            {
                Course courseToRemove = base.GetEntity(entity.CourseID);

                if (courseToRemove is null)
                    throw new CourseDataException("El curso no existe.");


                courseToRemove.Deleted = true;
                courseToRemove.DeletedDate = DateTime.Now;
                courseToRemove.UserDeleted = entity.UserDeleted;

                base.Update(courseToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el curso", ex.ToString());
            }
        }

        public List<CursoModel> GetCoursesByDepartment(int departmentId)
        {
            List<CursoModel> cursos = new List<CursoModel>();

            try
            {

                this.logger.LogInformation($"Pase por aqui: {departmentId}");

                cursos = (from cu in base.GetEntities()
                          join de in context.Departments.ToList() on cu.DepartmentID equals de.DepartmentID
                          where cu.DepartmentID == departmentId
                           && !cu.Deleted
                          select new CursoModel()
                          {
                              CourseId = cu.CourseID,
                              Credits = cu.Credits,
                              DeparmentName = de.Name,
                              DepartmentID = de.DepartmentID,
                              Title = cu.Title
                          }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los cursos: {ex.Message}", ex.ToString());
            }

            return cursos;
        }

        public List<CursoModel> GetCourses()
        {
            List<CursoModel> cursos = new List<CursoModel>();

            try
            {

                cursos = (from cu in base.GetEntities()
                          join de in context.Departments.ToList() on cu.DepartmentID equals de.DepartmentID
                          where !cu.Deleted
                          select new CursoModel()
                          {
                              CourseId = cu.CourseID,
                              Credits = cu.Credits,
                              DeparmentName = de.Name,
                              DepartmentID = de.DepartmentID,
                              Title = cu.Title
                          }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los cursos: {ex.Message}", ex.ToString());
            }

            return cursos;
        }

        public CursoModel GetCourse(int courseId)
        {
            CursoModel cursoModel = new CursoModel();


            try
            {
                if (!base.Exists(cu => cu.CourseID == courseId))
                    throw new Exception("Curso no existe..");


                cursoModel = (from co in this.context.Course
                             join de in this.context.Departments on co.DepartmentID equals de.DepartmentID
                             where co.CourseID == courseId
                             select new CursoModel()
                             {
                                 CourseId = co.CourseID,
                                 Credits = co.Credits,
                                 DeparmentName = de.Name,
                                 DepartmentID = de.DepartmentID,
                                 Title = co.Title

                             }).FirstOrDefault();


              


            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el curso", ex.ToString());
                throw new CourseDataException("Curso no existe..");
            }

            return cursoModel;
        }

    }
}

