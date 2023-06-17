using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

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

       
        [HttpGet("GetCourse")]
        public IActionResult Get([FromQuery] int id)
        {
            var course = new CursoModel();


            try
            {
                course = this.courseRepository.GetCourse(id);
            }
            catch (CourseException ex)
            {
                var result = new { Success = false, ErrorMessage = ex.Message };
                return BadRequest(result);
            }
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
