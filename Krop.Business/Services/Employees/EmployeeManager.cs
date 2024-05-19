using AutoMapper;
using Krop.Business.Features.Employees.Dtos;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Employees.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

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
        public async Task<IDataResult<IEnumerable<GetEmployeeDTO>>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetEmployeeDTO>>(
                _mapper.Map<List<GetEmployeeDTO>>(employees));

        }
        #endregion
        #region Search
        public async Task<IDataResult<GetEmployeeDTO>> GetByIdAsync(Guid id)
        {
            var employee = await _employeeBusinessRules.CheckByEmployeeId(id);

            return new SuccessDataResult<GetEmployeeDTO>(
                _mapper.Map<GetEmployeeDTO>(employee));
        }
        #endregion
    }
}
