using School.Application.Core;
using School.Application.Dtos.Department;
using School.Domain.Entities;

namespace School.Application.Extentions
{
    public static class DepartamentAppExtention
    {

        public static ServiceResult IsValidDeparment(this DepartmentDto model) 
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.Name))
            {
                result.Message = "El nombre del departamento es requerido.";
                result.Success = false;
                return result;
            }

            if (model.Name.Length > 50)
            {
                result.Message = "El nombre del departamento tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (!model.Budget.HasValue)
            {
                result.Message = "El presupuesto es requerido.";
                result.Success = false;
                return result;
            }

            if (model.Budget <= 0)
            {
                result.Message = "El presupuesto no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (!model.StartDate.HasValue)
            {
                result.Message = "El start date es requerido";
                result.Success = false;
                return result;
            }


            return result;
        }
        public static Department ConvertDtoAddToEntity(this DepartmentAddDto departmentAddDto)
        {
            return new Department()
            {
                Administrator = departmentAddDto.Administrator,
                Budget = departmentAddDto.Budget.Value,
                CreationDate = departmentAddDto.ChangeDate, 
                CreationUser= departmentAddDto.ChangeUser, 
                Name= departmentAddDto.Name, 
                StartDate= departmentAddDto.StartDate.Value
            };
        }
        public static Department ConvertDtoUpdateToEntity(this DepartmentUpdateDto departmentUpdateDto)
        {
            return new Department()
            {
                Administrator = departmentUpdateDto.Administrator,
                Budget = departmentUpdateDto.Budget.Value,
                ModifyDate = departmentUpdateDto.ChangeDate,
                UserMod = departmentUpdateDto.ChangeUser,
                Name = departmentUpdateDto.Name,
                StartDate = departmentUpdateDto.StartDate.Value, 
                DepartmentID= departmentUpdateDto.DepartmentID
            };
        }

    }
}
