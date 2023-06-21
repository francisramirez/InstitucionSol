using System;
using Microsoft.Extensions.Logging;
using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Infrastructure.Interfaces;

namespace School.Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILogger<CourseService> logger;

        public CourseService(ICourseRepository courseRepository, ILogger<CourseService> logger)
        {
            this.courseRepository = courseRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var courses = this.courseRepository.GetCourses();
                result.Data = courses;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los cursos";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var course = this.courseRepository.GetCourse(id);
                result.Data = course;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Remove(CourseRemoveDto model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Save(CourseAddDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (string.IsNullOrEmpty(model.Title))
                {
                    result.Message = "El nombre del curso es requerido";
                    result.Success = false;
                    return result;
                }

                if (model.Title.Length > 100)
                {
                    result.Message = "La longitud del nombre es inválida";
                    result.Success = false;
                    return result;
                }

                if (!model.Credits.HasValue)
                {
                    result.Message = "El credito del curso es requerido.";
                    result.Success = false;
                    return result;
                }

                if (!model.DepartmentID.HasValue)
                {
                    result.Message = "El departamento es requerido.";
                    result.Success = false;
                    return result;
                }


                this.courseRepository.Add(new Domain.Entities.Course()
                {
                    Credits = model.Credits.Value,
                    DepartmentID = model.DepartmentID.Value,
                    CreationDate = model.ChangeDate,
                    CreationUser = model.ChangeUser, Title = model.Title
                });

                result.Message = "Curso creado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(CourseUpdateDto model)
        {
            throw new System.NotImplementedException();
        }
    }
}
