
using System;

namespace School.Infrastructure.Exceptions
{
    public class CourseDataException : Exception
    {
        public CourseDataException(string message) : base(message)
        {

        }
    }
}
