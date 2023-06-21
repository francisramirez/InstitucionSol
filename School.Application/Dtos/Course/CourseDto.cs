
namespace School.Application.Dtos.Course
{
    public abstract class CourseDto : DtoBase
    {
        public string? Title { get; set; }
        public int? Credits { get; set; }
        public int? DepartmentID { get; set; }
    }
}
