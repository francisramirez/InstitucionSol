using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;

namespace InstitucionSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        [HttpGet("GetCourses")]
        public IActionResult Get()
        {
            var courses = this.courseRepository.GetCourses();
            return Ok(courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = this.courseRepository.GetCourse(id);
            return Ok(course);
        }
       
        [HttpPost("Save")]
        public IActionResult Post([FromBody] Course course)
        {
            this.courseRepository.Add(course);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Course course)
        {
            this.courseRepository.Update(course);
            return Ok();
        }


    }
}
