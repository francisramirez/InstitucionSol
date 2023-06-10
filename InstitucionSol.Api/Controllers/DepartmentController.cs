using Microsoft.AspNetCore.Mvc;
using School.Application.Dtos.Department;
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
        public IActionResult Post([FromBody] DepartmentAddDto departmentAdd)
        {

            this.departmentRepository.Add(new Department()
            {
                Administrator = departmentAdd.Administrator,
                Budget = departmentAdd.Budget,
                CreationDate = departmentAdd.ChangeDate,
                CreationUser = departmentAdd.ChangeUser,
                Name = departmentAdd.Name,
                StartDate = departmentAdd.StartDate
            });

            return Ok();
        }


        [HttpPost("Update")]
        public IActionResult Put([FromBody] DepartmentUpdateDto departmentUpdate)
        {


            Department departmentToUpdate = new Department()
            {
                Administrator = departmentUpdate.Administrator,
                Budget = departmentUpdate.Budget,
                ModifyDate = departmentUpdate.ChangeDate,
                UserMod = departmentUpdate.ChangeUser,
                Name = departmentUpdate.Name,
                StartDate = departmentUpdate.StartDate,
                DepartmentID = departmentUpdate.DepartmentID,
            };

            this.departmentRepository.Update(departmentToUpdate);
            return Ok();
        }

        
        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] DepartmentRemoveDto departmentRemoveDto)
        {
            Department departmentToDelete = new Department()
            {
                Deleted = departmentRemoveDto.Eliminado,
                DeletedDate = departmentRemoveDto.ChangeDate, 
                DepartmentID= departmentRemoveDto.DepartmentID, 
                UserDeleted= departmentRemoveDto.ChangeUser
            };

            this.departmentRepository.Remove(departmentToDelete);
            return Ok();
        }
    }
}
