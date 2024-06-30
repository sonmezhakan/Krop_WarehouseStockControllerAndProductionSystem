using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Employees.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Employees;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.Employees
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }
        #region Add 
        [TransactionScope]
        [ValidationAspect(typeof(CreateEmployeeValidator))]
        public async Task<IResult> AddAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.EmployeeCannotBeDuplicatedWhenInserted(createEmployeeDTO.AppUserId));
            if (!result.Success)
                return result;

            await _employeeRepository.AddAsync(
                _mapper.Map<Employee>(createEmployeeDTO));
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                EmployeeCacheKeys.GetAllAsync,
                EmployeeCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        [ValidationAspect(typeof(UpdateEmployeeValidator))]
        public async Task<IResult> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO)
        {
            var result = await _employeeRepository.GetAsync(e => e.AppUserId == updateEmployeeDTO.AppUserId);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound);

            Employee employee = _mapper.Map(updateEmployeeDTO, result);

            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
           {
                EmployeeCacheKeys.GetAllAsync,
                EmployeeCacheKeys.GetAllComboBoxAsync,
                $"{EmployeeCacheKeys.GetByIdAsync}{updateEmployeeDTO.AppUserId}",
                $"{EmployeeCacheKeys.GetByIdCartAsync}{updateEmployeeDTO.AppUserId}"
           });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetEmployeeListDTO>>> GetAllAsync()
        {
            IEnumerable<GetEmployeeListDTO>? getEmployeeListDTOs = await _cacheHelper.GetOrAddListAsync(
                EmployeeCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _employeeRepository.GetAllAsync(includeProperties: new Expression<Func<Employee, object>>[]
                         {
                             a=>a.AppUser,
                             d=>d.Department,
                             b=>b.Branch
                         });
                    return result is null ? null : _mapper.Map<IEnumerable<GetEmployeeListDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetEmployeeListDTO>>(getEmployeeListDTOs);
        }

        public async Task<IDataResult<IEnumerable<GetEmployeeComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetEmployeeComboBoxDTO> getEmployeeComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                EmployeeCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _employeeRepository.GetAllComboBoxAsync();
                    return _mapper.Map<IEnumerable<GetEmployeeComboBoxDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetEmployeeComboBoxDTO>>(getEmployeeComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetEmployeeDTO>> GetByIdAsync(Guid id)
        {
            GetEmployeeDTO? getEmployeeDTO = await _cacheHelper.GetOrAddAsync(
                $"{EmployeeCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _employeeRepository.GetAsync(x=>x.Id == id);
                    return result is null ? null : _mapper.Map<GetEmployeeDTO>(result);
                },
                60
                );
                return getEmployeeDTO is null ?
                new ErrorDataResult<GetEmployeeDTO>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound):
                new SuccessDataResult<GetEmployeeDTO>(getEmployeeDTO);
        }

        public async Task<IDataResult<GetEmployeeCartDTO>> GetByIdCartAsync(Guid Id)
        {
            GetEmployeeCartDTO? getEmployeeCartDTO = await _cacheHelper.GetOrAddAsync(
                $"{EmployeeCacheKeys.GetByIdCartAsync}{Id}",
                async () =>
                {
                    var result = await _employeeRepository.GetAsync(predicate: x => x.AppUserId == Id,
                includeProperties: new Expression<Func<Employee, object>>[]
                {
                    d=>d.Department,
                    b=>b.Branch
                });
                    return result is null ? null : _mapper.Map<GetEmployeeCartDTO>(result);
                },
                60
                );
                return getEmployeeCartDTO is null ?
                    new ErrorDataResult<GetEmployeeCartDTO>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound):
                    new SuccessDataResult<GetEmployeeCartDTO>(getEmployeeCartDTO);
        }
        #endregion
    }
}
