using School.Application.Dtos.Course;
using School.Infrastructure.Models;
using School.Web.Models.Reponses;

namespace School.Web.Services
{
    public interface ICourseApiService
    {
        CourseDetailResponse GetCourse(int id);
        CourseListReponse GetCourses();
        CourseUpdateResponse Update(CourseUpdateDto courseUpdateDto);
        CourseSaveReponse Save(CourseAddDto courseAddDto);

    }
}
