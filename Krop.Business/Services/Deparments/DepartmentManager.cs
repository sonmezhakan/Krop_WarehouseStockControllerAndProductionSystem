using AutoMapper;
using Krop.Business.Features.Departments.Dtos;
using Krop.Business.Features.Departments.ExceptionHelpers;
using Krop.Business.Features.Departments.Rules;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.Deparments
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        private readonly DepartmentExceptionHelper _departmentExceptionHelper;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules, DepartmentExceptionHelper departmentExceptionHelper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
            _departmentExceptionHelper = departmentExceptionHelper;
        }

        #region Add
        public async Task<bool> AddAsync(CreateDepartmentDTO createDepartmentDTO)
        {
            await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(createDepartmentDTO.DepartmentName);//DepartmentName Rule

            Department department = _mapper.Map<Department>(createDepartmentDTO);

            return await _departmentRepository.AddAsync(department);
        }

        public async Task<bool> AddRangeAsync(List<CreateDepartmentDTO> createDepartmentDTOs)
        {
            createDepartmentDTOs.ForEach(async d =>
            {
                await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(d.DepartmentName);//DepartmentName Rule
            });

            List<Department> departments = _mapper.Map<List<Department>>(createDepartmentDTOs);

            return await _departmentRepository.AddRangeAsync(departments);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO)
        {
            Department department = await _departmentRepository.FindAsync(updateDepartmentDTO.Id);
            if (department is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.DepartmentName, updateDepartmentDTO.DepartmentName);//DepartmentName Rule

            department = _mapper.Map(updateDepartmentDTO, department);

            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<bool> UpdateRangeAsync(List<UpdateDepartmentDTO> updateDepartmentDTOs)
        {
            updateDepartmentDTOs.ForEach(async d =>
            {
                Department department = await _departmentRepository.FindAsync(d.Id);
                if (department is null)
                    _departmentExceptionHelper.ThrowDepartmentNotFound();

                await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.DepartmentName, d.DepartmentName);//DepartmentName Rule
            });

            List<Department> departments = _mapper.Map<List<Department>>(updateDepartmentDTOs);

            return await _departmentRepository.UpdateRangeAsync(departments);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Department department = await _departmentRepository.FindAsync(id);
            if (department is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            return await _departmentRepository.DeleteAsync(department);
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            List<Department> departments = new();
            ids.ForEach(async d =>
            {
                Department department = await _departmentRepository.FindAsync(d);
                if (department is null)
                    _departmentExceptionHelper.ThrowDepartmentNotFound();

                departments.Add(department);
            });

            return await _departmentRepository.DeleteRangeAsync(departments);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetDepartmentDTO>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return _mapper.Map<List<GetDepartmentDTO>>(departments);
        }
        #endregion
        #region Search
        public async Task<GetDepartmentDTO> GetByDepartmentName(string departmentName)
        {
            Department department = await _departmentRepository.GetAsync(d => d.DepartmentName == departmentName);
            if (department is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            return _mapper.Map<GetDepartmentDTO>(department);
        }

        public async Task<GetDepartmentDTO> GetById(Guid id)
        {
            Department department = await _departmentRepository.FindAsync(id);
            if (department is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            return _mapper.Map<GetDepartmentDTO>(department);
        }
        #endregion
    }
}
