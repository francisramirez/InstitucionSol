namespace School.Application.Dtos.Course
{
    public class CourseRemoveDto : DtoBase
    {
        public int CourseId { get; set; }
        public bool Deleted { get; set; }
    }
}
