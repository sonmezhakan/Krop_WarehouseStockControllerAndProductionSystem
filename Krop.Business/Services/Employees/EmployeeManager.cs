using AutoMapper;
using Krop.Business.Features.Employees.Dtos;
using Krop.Business.Features.Employees.ExceptionHelpers;
using Krop.Business.Features.Employees.Rules;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.Employees
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeExceptionHelper _employeeExceptionHelper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;


        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeExceptionHelper employeeExceptionHelper, EmployeeBusinessRules employeeBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeExceptionHelper = employeeExceptionHelper;
            _employeeBusinessRules = employeeBusinessRules;
        }
        #region Add
        public async Task<bool> AddAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            await _employeeBusinessRules.EmployeeCannotBeDuplicatedWhenInserted(createEmployeeDTO.AppUserId);//AppUserId Rule
            Employee employee = _mapper.Map<Employee>(createEmployeeDTO);

            return await _employeeRepository.AddAsync(employee);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO)
        {
            Employee employee = await _employeeRepository.FindAsync(updateEmployeeDTO.AppUserId);
            if (employee is null)
                _employeeExceptionHelper.ThrowEmployeeNotFound();

            employee = _mapper.Map(updateEmployeeDTO, employee);

            return await _employeeRepository.UpdateAsync(employee);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetEmployeeDTO>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return _mapper.Map<List<GetEmployeeDTO>>(employees);

        }
        #endregion
        #region Search
        public async Task<GetEmployeeDTO> GetByIdAsync(Guid id)
        {
            Employee employee = await _employeeRepository.FindAsync(id);
            if (employee is null)
                _employeeExceptionHelper.ThrowEmployeeNotFound();

            return _mapper.Map<GetEmployeeDTO>(employee);
        }
        #endregion
    }
}
