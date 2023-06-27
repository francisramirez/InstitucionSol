using System;
using Microsoft.Extensions.Logging;
using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Department;
using School.Domain.Entities;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Application.Extentions;
namespace School.Application.Service
{

    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<DepartamentService> logger;

        public DepartamentService(IDepartmentRepository departmentRepository,
                                  ILogger<DepartamentService> logger)
        {
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.departmentRepository.GetDepartments();
            }
            catch (DepartmentException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los deparmentos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.departmentRepository.GetDepartmentById(id);
            }
            catch (DepartmentException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los deparmentos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(DepartmentRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.departmentRepository.Remove(new Department()
                {
                    DepartmentID = model.DepartmentID,
                    Deleted = model.Deleted, 
                    DeletedDate= model.ChangeDate, 
                    UserDeleted= model.ChangeUser
                });

                result.Message = "Departamento eliminado correctamente.";

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el departamento.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(DepartmentAddDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.IsValidDeparment().Success)
                return result;

            try
            {

                var department = model.ConvertDtoAddToEntity();

                this.departmentRepository.Add(department);

                result.Message = "Departamento agregado correctamente.";
            }
            catch (DepartmentException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el departamento.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(DepartmentUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.IsValidDeparment().Success)
                return result;

            try
            {
                var deparment = model.ConvertDtoUpdateToEntity();

                this.departmentRepository.Update(deparment);

                result.Message = "Departamento actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el departamento.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }



            return result;
        }
    }
}
