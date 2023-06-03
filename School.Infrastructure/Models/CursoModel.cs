

namespace School.Infrastructure.Models
{
    public class CursoModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
       public string? DeparmentName { get; set; }
    }
}
