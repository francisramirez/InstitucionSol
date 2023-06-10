using System;


namespace School.Application.Dtos.Department
{
    public abstract class DepartmentDto : DtoBase
    {
        public string? Name { get; set; }
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }

    }
}
