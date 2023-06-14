
using School.Domain.Entities;
using School.Infrastructure.Models;

namespace School.Infrastructure.Extentions
{
    public static class CourseExtention
    {
        public static CursoModel ConvertCourseEntityToModel(this Course course)
        {
            CursoModel cursoModel = new CursoModel()
            {
                CourseId = course.CourseID,
                Credits = course.Credits,
                DepartmentID = course.DepartmentID,
                Title = course.Title
            };

            return cursoModel;
        }
    }
}
