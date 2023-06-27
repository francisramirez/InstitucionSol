
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Domain.Entities;

namespace School.Application.Extentions
{
    public static class CourseAppExtention
    {
        public static ServiceResult IsValidCourse(this CourseDto model) 
        {
            ServiceResult result = new ServiceResult();

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


            return result;
        }
        public static Course ConvertToCourseAddDtoToCourseEntiy(this CourseAddDto courseAdd) 
        {
            return new Course()
            {
                Credits = courseAdd.Credits.Value,
                DepartmentID = courseAdd.DepartmentID.Value,
                Title = courseAdd.Title,
                CreationDate = courseAdd.ChangeDate,
                CreationUser = courseAdd.ChangeUser,
            };
        }
        public static Course ConvertToCourseUpdateDtoToCourseEntiy(this CourseUpdateDto courseUpdate)
        {
            return new Course()
            {
                CourseID = courseUpdate.CourseId,
                ModifyDate = courseUpdate.ChangeDate,
                UserMod = courseUpdate.ChangeUser,
                Credits = courseUpdate.Credits.Value,
                DepartmentID = courseUpdate.DepartmentID.Value,
                Title = courseUpdate.Title
            };
        }
    }
}
