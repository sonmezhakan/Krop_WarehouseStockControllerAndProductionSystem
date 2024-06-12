using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Branches.Constants;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Branches.Validations;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Caching;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Brands;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Branches
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly IStockService _stockService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public BranchManager(IBranchRepository branchRepository, IMapper mapper, BranchBusinessRules branchBusinessRules, IStockService stockService,IUnitOfWork unitOfWork,ICacheHelper cacheHelper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _stockService = stockService;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add
        
        [TransactionScope]
        [ValidationAspect(typeof(CreateBranchValidator))]
        public async Task<IResult> AddAsync(CreateBranchDTO createBranchDTO)
        {
            var result = BusinessRules.Run(await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(createBranchDTO.BranchName));//BranchName Rule
            if (!result.Success)
                return result;

            Branch branch = _mapper.Map<Branch>(createBranchDTO);
            await _stockService.NewBranchAddedProductAsync(branch.Id);//Stok dan gelen listesi şubenin stoklarına aktarıyoruz.

            await _branchRepository.AddAsync(branch);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BranchCacheKeys.GetAllAsync,
                BranchCacheKeys.GetAllComboBoxAsync,
            });
            return new SuccessResult();
        }

        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateBranchDTO))]
        public async Task<IResult> UpdateAsync(UpdateBranchDTO updateBranchDTO)
        {
            var branch = await _branchBusinessRules.CheckByBranchId(updateBranchDTO.Id);
            if (!branch.Success)
                return branch;

            await _branchRepository.UpdateAsync(
                _mapper.Map(updateBranchDTO, branch.Data));

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BranchCacheKeys.GetAllAsync,
                BranchCacheKeys.GetAllComboBoxAsync,
                $"{BranchCacheKeys.GetByIdAsync }{updateBranchDTO.Id }"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        [TransactionScope]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var branch = await _branchBusinessRules.CheckByBranchId(id);
            if (!branch.Success)
                return branch;

            await _stockService.BranchDeletedProductAsync(branch.Data.Id);//Belirtilen şubeye ait stokdan ürünler sil.
            await _branchRepository.DeleteAsync(branch.Data);//Şubeyi sil

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BranchCacheKeys.GetAllAsync,
                BranchCacheKeys.GetAllComboBoxAsync,
                $"{BranchCacheKeys.GetByIdAsync }{id }"
            });
            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetBranchDTO>>> GetAllAsync()
        {
            IEnumerable<GetBranchDTO> getBranchDTOs = await _cacheHelper.GetOrAddListAsync(
                BranchCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _branchRepository.GetAllAsync();
                    return _mapper.Map<IEnumerable<GetBranchDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetBranchDTO>>(getBranchDTOs);
        }
      
        public async Task<IDataResult<IEnumerable<GetBranchComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetBranchComboBoxDTO> getBranchComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                BranchCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _branchRepository.GetAllComboBoxAsync();
                    return _mapper.Map<IEnumerable<GetBranchComboBoxDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetBranchComboBoxDTO>>(getBranchComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetBranchDTO>> GetByIdAsync(Guid id)
        {
            GetBranchDTO getBranchDTO = await _cacheHelper.GetOrAddAsync(
                $"{BranchCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _branchBusinessRules.CheckByBranchId(id);
                    return _mapper.Map<GetBranchDTO>(result.Data);
                },
                60
                );
            if (getBranchDTO is null)
                return new ErrorDataResult<GetBranchDTO>(StatusCodes.Status404NotFound, BranchMessages.BranchNotFound);

            return new SuccessDataResult<GetBranchDTO>(getBranchDTO);
        }
        #endregion
    }
}
