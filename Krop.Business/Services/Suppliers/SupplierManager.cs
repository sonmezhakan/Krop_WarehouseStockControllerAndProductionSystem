using AutoMapper;
using Krop.Business.Features.Suppliers.Constants;
using Krop.Business.Features.Suppliers.Rules;
using Krop.Business.Features.Suppliers.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Suppliers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Suppliers
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly SupplierBusinessRules _supplierBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public SupplierManager(ISupplierRepository supplierRepository,IMapper mapper,SupplierBusinessRules supplierBusinessRules,IUnitOfWork unitOfWork,ICacheHelper cacheHelper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }
        #region Add
        [ValidationAspect(typeof(CreateSupplierValidator))]
        public async Task<IResult> AddAsync(CreateSupplierDTO createSupplierDTO)
        {
            Supplier result = _mapper.Map<Supplier>(createSupplierDTO);
            await _supplierRepository.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                SupplierCacheKeys.GetAllAsync,
                SupplierCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateSupplierValidator))]
        public async Task<IResult> UpdateAsync(UpdateSupplierDTO updateSupplierDTO)
        {
            var result = await _supplierRepository.GetAsync(x=>x.Id == updateSupplierDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, SupplierMessages.SupplierNotFound);

            Supplier supplier = _mapper.Map(updateSupplierDTO,result);
            await _supplierRepository.UpdateAsync(supplier);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                SupplierCacheKeys.GetAllAsync,
                SupplierCacheKeys.GetAllComboBoxAsync,
                $"{SupplierCacheKeys.GetByIdAsync}{updateSupplierDTO.Id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _supplierRepository.GetAsync(x => x.Id == id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, SupplierMessages.SupplierNotFound);

            await _supplierRepository.DeleteAsync(result);
            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                SupplierCacheKeys.GetAllAsync,
                SupplierCacheKeys.GetAllComboBoxAsync,
                $"{SupplierCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetSupplierDTO>>> GetAllAsync()
        {
            IEnumerable<GetSupplierDTO>? getSupplierDTOs = await _cacheHelper.GetOrAddListAsync(
                SupplierCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _supplierRepository.GetAllAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetSupplierDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetSupplierDTO>>(getSupplierDTOs);
        }

        public async Task<IDataResult<IEnumerable<GetSupplierComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetSupplierComboBoxDTO>? getSupplierComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                SupplierCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _supplierRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetSupplierComboBoxDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetSupplierComboBoxDTO>>(getSupplierComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetSupplierDTO>> GetByIdAsync(Guid id)
        {
            GetSupplierDTO? getSupplierDTO = await _cacheHelper.GetOrAddAsync(
                $"{SupplierCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _supplierRepository.GetAsync(x=>x.Id == id);
                    return result is null ? null : _mapper.Map<GetSupplierDTO>(result);
                },
                30
                );
                return getSupplierDTO is null ? 
                    new ErrorDataResult<GetSupplierDTO>(StatusCodes.Status404NotFound, SupplierMessages.SupplierNotFound):
                    new SuccessDataResult<GetSupplierDTO>(getSupplierDTO);
        }
   
        #endregion
    }
}
