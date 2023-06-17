
using Microsoft.Extensions.Logging;
using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Department;
using School.Domain.Entities;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using System;

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
            throw new NotImplementedException();
        }

        public ServiceResult Save(DepartmentAddDto model)
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


            try
            {
                this.departmentRepository.Add(new Department()
                {
                    Administrator = model.Administrator,
                    Budget = model.Budget.Value,
                    CreationDate = model.ChangeDate,
                    CreationUser = model.ChangeUser,
                    Name = model.Name,
                    StartDate = model.StartDate.Value
                });

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
            throw new NotImplementedException();
        }
    }
}
