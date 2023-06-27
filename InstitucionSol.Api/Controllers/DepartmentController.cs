using Microsoft.AspNetCore.Mvc;
using School.Application.Contract;
using School.Application.Dtos.Department;

namespace InstitucionSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
       
        private readonly IDepartamentService departamentService;

        public DepartmentController(IDepartamentService departamentService)
        {
            this.departamentService = departamentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var departments = this.departamentService.Get();
            return Ok(departments);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var depto = this.departamentService.GetById(id);
            return Ok(depto);
        }


        [HttpPost("Save")]
        public IActionResult Post([FromBody] DepartmentAddDto departmentAdd)
        {

            var result = this.departamentService.Save(departmentAdd);

            return Ok(result);
        }


        [HttpPost("Update")]
        public IActionResult Put([FromBody] DepartmentUpdateDto departmentUpdate)
        {


            var result = this.departamentService.Update(departmentUpdate);
             
            return Ok(result);
        }

        
        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] DepartmentRemoveDto departmentRemoveDto)
        {
            
            var result = this.departamentService.Remove(departmentRemoveDto);
            return Ok(result);
        }
    }
}
