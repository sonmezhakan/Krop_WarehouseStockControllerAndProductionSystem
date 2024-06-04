using AutoMapper;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Employees.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.Employees;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.Employees
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;


        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
        }
        #region Add
        [ValidationAspect(typeof(CreateEmployeeValidator))]
        public async Task<IResult> AddAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            await _employeeBusinessRules.EmployeeCannotBeDuplicatedWhenInserted(createEmployeeDTO.AppUserId);//AppUserId Rule
            
            await _employeeRepository.AddAsync(
                _mapper.Map<Employee>(createEmployeeDTO));
            return new SuccessResult();
        }
        #endregion
        #region Update
        public async Task<IResult> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = await _employeeBusinessRules.CheckByEmployeeId(updateEmployeeDTO.AppUserId);

            employee = _mapper.Map(updateEmployeeDTO, employee);

            await _employeeRepository.UpdateAsync(employee);

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
            var employee = await _employeeBusinessRules.CheckByEmployeeId(id);

            return new SuccessDataResult<GetEmployeeDTO>(
                _mapper.Map<GetEmployeeDTO>(employee));
        }

        public async Task<IDataResult<GetEmployeeCartDTO>> GetByIdCartAsync(Guid Id)
        {
            var employee = await _employeeRepository.GetAsync(predicate:x=>x.AppUserId ==Id,
                includeProperties:new Expression<Func<Employee, object>>[]
                {
                    d=>d.Department,
                    b=>b.Branch
                });

            return new SuccessDataResult<GetEmployeeCartDTO>(
                _mapper.Map<GetEmployeeCartDTO>(employee));
        }
        #endregion
    }
}
