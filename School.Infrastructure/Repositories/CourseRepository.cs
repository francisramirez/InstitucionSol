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
        public List<CursoModel> GetCoursesByDepartment(int departmentId)
        {
            List<CursoModel> cursos = new List<CursoModel>();

            try
            {

                this.logger.LogInformation($"Pase por aqui: { departmentId }");

                cursos = (from cu in base.GetEntities()
                          join de in context.Departments.ToList() on cu.DepartmentID equals de.DepartmentID
                          where cu.DepartmentID == departmentId
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

        public override void Add(Course entity)
        {

            if (this.Exists(cd => cd.Title == entity.Title))
                throw new CourseException("El curso ya existe.");
            


            base.SaveChanges();
        }



    }
}

