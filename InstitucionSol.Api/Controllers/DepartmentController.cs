using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;

namespace InstitucionSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var departments = this.departmentRepository.GetDepartments();
            return Ok(departments);
        }

       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var depto = this.departmentRepository.GetDepartmentById(id);
            return Ok(depto);
        }

       
        [HttpPost("Save")]
        public void Post([FromBody] Department department)
        {

        }

      
        [HttpPost("Update")]
        public void Put([FromBody] Department department)
        {

        }

        
        [HttpPost("Remove")]
        public void Delete([FromBody] Department department)
        {
        }
    }
}
