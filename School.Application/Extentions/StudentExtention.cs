using School.Application.Dtos.Department;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Extentions
{
    public static class DepartamentExtention
    {
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
