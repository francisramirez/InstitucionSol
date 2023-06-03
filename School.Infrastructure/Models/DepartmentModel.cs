

using System;

namespace School.Infrastructure.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public int? Administrator { get; set; }

        public DateTime StartDate { get; set; }

    }
}
