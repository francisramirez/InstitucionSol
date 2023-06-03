
using System;

namespace School.Infrastructure.Exceptions
{
    public class DepartmentException : Exception
    {
        public DepartmentException(string message) :base(message)
        {
            // x logica para almacenar el error //
        }
    }
}
