using Microsoft.AspNetCore.Mvc;
using School.Application.Contract;
using School.Application.Dtos.Course;
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
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        [HttpGet("GetCourses")]
        public IActionResult Get()
        {
            var result = this.courseService.Get();

            if (!result.Success)
                return BadRequest(result);
            

            return Ok(result);
        }

       
        [HttpGet("GetCourse")]
        public IActionResult Get([FromQuery] int id)
        {
            var result = this.courseService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
             
        }
       
        [HttpPost("Save")]
        public IActionResult Post([FromBody] CourseAddDto courseAddDto)
        {
            var result = this.courseService.Save(courseAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Course course)
        {
            //this.courseRepository.Update(course);
            return Ok();
        }


    }
}
