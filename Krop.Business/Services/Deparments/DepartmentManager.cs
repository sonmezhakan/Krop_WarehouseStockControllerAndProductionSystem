﻿using AutoMapper;
using Krop.Business.Features.Departments.Constants;
using Krop.Business.Features.Departments.Rules;
using Krop.Business.Features.Departments.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Departments;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Deparments
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules,IUnitOfWork unitOfWork,ICacheHelper cacheHelper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add
        [ValidationAspect(typeof(CreateDepartmentValidator))]
        public async Task<IResult> AddAsync(CreateDepartmentDTO createDepartmentDTO)
        {
            var result = BusinessRules.Run(await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(createDepartmentDTO.DepartmentName));
            if (!result.Success)
                return result;

            await _departmentRepository.AddAsync(
                _mapper.Map<Department>(createDepartmentDTO));
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                DepartmentCacheKeys.GetAllAsync,
                DepartmentCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateDepartmentValidator))]
        public async Task<IResult> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = await _departmentRepository.GetAsync(x => x.Id == updateDepartmentDTO.Id);
            if (department is null)
                return new ErrorResult(StatusCodes.Status404NotFound, DepartmentMessages.DepartmentNotFound);

            var result = BusinessRules.Run(await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.DepartmentName, updateDepartmentDTO.DepartmentName));
            if (!result.Success)
                return result;

            await _departmentRepository.UpdateAsync(
                _mapper.Map(updateDepartmentDTO, department));
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                DepartmentCacheKeys.GetAllAsync,
                DepartmentCacheKeys.GetAllComboBoxAsync,
                $"{DepartmentCacheKeys.GetByIdAsync}{updateDepartmentDTO.Id}"
            });
            return new SuccessResult();
        }
       
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var department = await _departmentRepository.GetAsync(x=>x.Id == id);
            if (department is null)
                return new ErrorResult(StatusCodes.Status404NotFound, DepartmentMessages.DepartmentNotFound);

            await _departmentRepository.DeleteAsync(department);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                DepartmentCacheKeys.GetAllAsync,
                DepartmentCacheKeys.GetAllComboBoxAsync,
                $"{DepartmentCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetDepartmentDTO>>> GetAllAsync()
        {
            IEnumerable<GetDepartmentDTO>? getDepartmentDTOs = await _cacheHelper.GetOrAddListAsync(
                DepartmentCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _departmentRepository.GetAllAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetDepartmentDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetDepartmentDTO>>(getDepartmentDTOs);
        }

        public async Task<IDataResult<IEnumerable<GetDepartmentComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetDepartmentComboBoxDTO>? getDepartmentComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                DepartmentCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _departmentRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetDepartmentComboBoxDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetDepartmentComboBoxDTO>>(getDepartmentComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetDepartmentDTO>> GetById(Guid id)
        {
            GetDepartmentDTO? getDepartmentDTO = await _cacheHelper.GetOrAddAsync(
                $"{DepartmentCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _departmentRepository.GetAsync(x=>x.Id == id);
                    return result is null ? null : _mapper.Map<GetDepartmentDTO>(result);
                },
                60
                );
                return getDepartmentDTO is null ?
                new ErrorDataResult<GetDepartmentDTO>(StatusCodes.Status404NotFound, DepartmentMessages.DepartmentNotFound):
                new SuccessDataResult<GetDepartmentDTO>(getDepartmentDTO);
        }  
        #endregion
    }
}
