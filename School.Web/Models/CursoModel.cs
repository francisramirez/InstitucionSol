namespace School.Web.Models
{
    public class CursoModel
    {
        public int courseId { get; set; }
        public string? title { get; set; }
        public int credits { get; set; }
        public int departmentID { get; set; }
        public string? deparmentName { get; set; }
    }
}
