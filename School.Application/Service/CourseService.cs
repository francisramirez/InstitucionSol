using System;
using Microsoft.Extensions.Logging;
using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;
using School.Application.Extentions;
namespace School.Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILogger<CourseService> logger;

        public CourseService(ICourseRepository courseRepository, 
                             ILogger<CourseService> logger)
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
               
                if (!model.IsValidCourse().Success)
                    return result;

                Course course = model.ConvertToCourseAddDtoToCourseEntiy();

                this.courseRepository.Add(course);

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
            ServiceResult result = new ServiceResult();

            if (!model.IsValidCourse().Success)
                return result;

            try
            {
                Course course = model.ConvertToCourseUpdateDtoToCourseEntiy();

                this.courseRepository.Update(course);

                result.Message = "Curso actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el curso";
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }
    }
}
