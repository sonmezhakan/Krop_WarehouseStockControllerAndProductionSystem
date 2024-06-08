using AutoMapper;
using Krop.Business.Features.Departments.Rules;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Departments;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Deparments
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
            _unitOfWork = unitOfWork;
        }

        #region Add
       
        public async Task<IResult> AddAsync(CreateDepartmentDTO createDepartmentDTO)
        {
            var result = BusinessRules.Run(await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(createDepartmentDTO.DepartmentName));
            if (!result.Success)
                return result;

            await _departmentRepository.AddAsync(
                _mapper.Map<Department>(createDepartmentDTO));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        /*[ValidationAspect(typeof(CreateDepartmentValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateDepartmentDTO> createDepartmentDTOs)
        {
            createDepartmentDTOs.ForEach(async d =>
            {
                await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenInserted(d.DepartmentName);//DepartmentName Rule
            });

            await _departmentRepository.AddRangeAsync(
                _mapper.Map<List<Department>>(createDepartmentDTOs));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }*/
        #endregion
        #region Update
        
        public async Task<IResult> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(updateDepartmentDTO.Id);
            if (!department.Success)
                return department;

            var result = BusinessRules.Run(await _departmentBusinessRules.DepartmentNameCannotBeDuplicateWhenUpdated(department.Data.DepartmentName, updateDepartmentDTO.DepartmentName));
            if (!result.Success)
                return result;

            await _departmentRepository.UpdateAsync(
                _mapper.Map(updateDepartmentDTO, department.Data));
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
       /* [ValidationAspect(typeof(UpdateDepartmentValidator))]
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
        }*/
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(id);
            if (!department.Success)
                return department;

            await _departmentRepository.DeleteAsync(department.Data);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        /*public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Department> departments = new();
            ids.ForEach(async d =>
            {
                var department = await _departmentBusinessRules.CheckByDepartmentId(d);

                departments.Add(department);
            });

            await _departmentRepository.DeleteRangeAsync(departments);

            return new SuccessResult();
        }*/
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
            if (!department.Success)
                return new ErrorDataResult<GetDepartmentDTO>(department.Status,department.Detail);

            return new SuccessDataResult<GetDepartmentDTO>(
                _mapper.Map<GetDepartmentDTO>(department.Data));
        }

        public async Task<IDataResult<GetDepartmentDTO>> GetById(Guid id)
        {
            var department = await _departmentBusinessRules.CheckByDepartmentId(id);
            if (!department.Success)
                return new ErrorDataResult<GetDepartmentDTO>(department.Status, department.Detail);

            return new SuccessDataResult<GetDepartmentDTO>(
                _mapper.Map<GetDepartmentDTO>(department.Data));
        }

        
        #endregion
    }
}
