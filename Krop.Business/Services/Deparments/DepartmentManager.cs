using AutoMapper;
using Krop.Business.Features.Departments.Rules;
using Krop.Business.Features.Departments.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.Departments;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Deparments
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
        }

        #region Add
        [ValidationAspect(typeof(CreateDepartmentValidator))]
        public async Task<IResult> AddAsync(CreateDepartmentDTO createDepartmentDTO)
        {
            await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(createDepartmentDTO.DepartmentName);//DepartmentName Rule

            await _departmentRepository.AddAsync(
                _mapper.Map<Department>(createDepartmentDTO));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(CreateDepartmentValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateDepartmentDTO> createDepartmentDTOs)
        {
            createDepartmentDTOs.ForEach(async d =>
            {
                await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(d.DepartmentName);//DepartmentName Rule
            });

            await _departmentRepository.AddRangeAsync(
                _mapper.Map<List<Department>>(createDepartmentDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateDepartmentValidator))]
        public async Task<IResult> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(updateDepartmentDTO.Id);//DepartmentId Rule
            await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.DepartmentName, updateDepartmentDTO.DepartmentName);//DepartmentName Rule

            await _departmentRepository.UpdateAsync(
                _mapper.Map(updateDepartmentDTO, department));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateDepartmentValidator))]
        public async Task<IResult> UpdateRangeAsync(List<UpdateDepartmentDTO> updateDepartmentDTOs)
        {
            updateDepartmentDTOs.ForEach(async d =>
            {
                var department = await _departmentBusinessRules.CheckByDepartmentId(d.Id);//DepartmentId Rule
                await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.DepartmentName, d.DepartmentName);//DepartmentName Rule
            });

            await _departmentRepository.UpdateRangeAsync(
                _mapper.Map<List<Department>>(updateDepartmentDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(id);

            await _departmentRepository.DeleteAsync(department);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Department> departments = new();
            ids.ForEach(async d =>
            {
                var department = await _departmentBusinessRules.CheckByDepartmentId(d);

                departments.Add(department);
            });

            await _departmentRepository.DeleteRangeAsync(departments);

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetDepartmentDTO>>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetDepartmentDTO>>(
                _mapper.Map<IEnumerable<GetDepartmentDTO>>(departments));
        }

        public async Task<IDataResult<IEnumerable<GetDepartmentComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _departmentRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetDepartmentComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetDepartmentComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetDepartmentDTO>> GetByDepartmentName(string departmentName)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentName(departmentName);

            return new SuccessDataResult<GetDepartmentDTO>(
                _mapper.Map<GetDepartmentDTO>(department));
        }

        public async Task<IDataResult<GetDepartmentDTO>> GetById(Guid id)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(id);

            return new SuccessDataResult<GetDepartmentDTO>(
                _mapper.Map<GetDepartmentDTO>(department));
        }

        
        #endregion
    }
}
