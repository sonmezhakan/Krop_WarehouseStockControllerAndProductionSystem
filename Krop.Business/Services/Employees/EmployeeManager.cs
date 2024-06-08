using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
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

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules,IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _unitOfWork = unitOfWork;
        }
        #region Add
        
        [TransactionScope]
        public async Task<IResult> AddAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            var result = BusinessRules.Run(await _employeeBusinessRules.EmployeeCannotBeDuplicatedWhenInserted(createEmployeeDTO.AppUserId));
            if (!result.Success)
                return result;
            
            await _employeeRepository.AddAsync(
                _mapper.Map<Employee>(createEmployeeDTO));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Update
        [TransactionScope]
        public async Task<IResult> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO)
        {
            var result = await _employeeBusinessRules.CheckByEmployeeId(updateEmployeeDTO.AppUserId);
            if (!result.Success)
                return result;

            Employee employee = _mapper.Map(updateEmployeeDTO, result.Data);

            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetEmployeeListDTO>>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync(includeProperties: new Expression<Func<Employee, object>>[]
            {
                a=>a.AppUser,
                d=>d.Department,
                b=>b.Branch
            });

            return new SuccessDataResult<IEnumerable<GetEmployeeListDTO>>(
                _mapper.Map<IEnumerable<GetEmployeeListDTO>>(employees));
        }

        public async Task<IDataResult<IEnumerable<GetEmployeeComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var employees = await _employeeRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetEmployeeComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetEmployeeComboBoxDTO>>(employees));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetEmployeeDTO>> GetByIdAsync(Guid id)
        {
            var result = await _employeeBusinessRules.CheckByEmployeeId(id);
            if (!result.Success)
                return new ErrorDataResult<GetEmployeeDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetEmployeeDTO>(
                _mapper.Map<GetEmployeeDTO>(result.Data));
        }

        public async Task<IDataResult<GetEmployeeCartDTO>> GetByIdCartAsync(Guid Id)
        {
            var employee = await _employeeRepository.GetAsync(predicate:x=>x.AppUserId ==Id,
                includeProperties:new Expression<Func<Employee, object>>[]
                {
                    d=>d.Department,
                    b=>b.Branch
                });
            if (employee is null)
                return new ErrorDataResult<GetEmployeeCartDTO>(StatusCodes.Status404NotFound,EmployeeMessages.EmployeeNotFound);

            return new SuccessDataResult<GetEmployeeCartDTO>(
                _mapper.Map<GetEmployeeCartDTO>(employee));
        }
        #endregion
    }
}
