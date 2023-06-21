using School.Application.Core;
using School.Application.Dtos.Course;

namespace School.Application.Contract
{
    public interface ICourseService : IBaseService<CourseAddDto, 
                                                  CourseUpdateDto, 
                                                  CourseRemoveDto>
    {
    }
}
