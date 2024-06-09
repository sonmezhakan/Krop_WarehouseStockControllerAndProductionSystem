using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Services.Stocks;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Branches;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Branches
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly IStockService _stockService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public BranchManager(IBranchRepository branchRepository, IMapper mapper, BranchBusinessRules branchBusinessRules, IStockService stockService,IUnitOfWork unitOfWork,EmployeeBusinessRules employeeBusinessRules,AppUserBusinessRules appUserBusinessRules)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _stockService = stockService;
            _unitOfWork = unitOfWork;
            _employeeBusinessRules = employeeBusinessRules;
            _appUserBusinessRules = appUserBusinessRules;
        }

        #region Add
        
        [TransactionScope]
        public async Task<IResult> AddAsync(CreateBranchDTO createBranchDTO)
        {
            var result = BusinessRules.Run(await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(createBranchDTO.BranchName));//BranchName Rule
            if (!result.Success)
                return result;

            Branch branch = _mapper.Map<Branch>(createBranchDTO);
            await _stockService.NewBranchAddedProductAsync(branch.Id);//Stok dan gelen listesi şubenin stoklarına aktarıyoruz.

            await _branchRepository.AddAsync(branch);

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        
        #endregion
        #region Update
        
        public async Task<IResult> UpdateAsync(UpdateBranchDTO updateBranchDTO)
        {
            var branch = await _branchBusinessRules.CheckByBranchId(updateBranchDTO.Id);
            if (!branch.Success)
                return branch;

            await _branchRepository.UpdateAsync(
                _mapper.Map(updateBranchDTO, branch.Data));

            await _unitOfWork.SaveChangesAsync();
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
            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetBranchDTO>>> GetAllAsync()
        {
            var result = await _branchRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetBranchDTO>>(
                _mapper.Map<IEnumerable<GetBranchDTO>>(result));
        }
      
        public async Task<IDataResult<IEnumerable<GetBranchComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _branchRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetBranchComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetBranchComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetBranchDTO>> GetByIdAsync(Guid id)
        {
            var result = await _branchBusinessRules.CheckByBranchId(id);
            if (!result.Success)
                return new ErrorDataResult<GetBranchDTO>(result.Status, result.Detail);

            return new SuccessDataResult<GetBranchDTO>(
                _mapper.Map<GetBranchDTO>(result.Data));
        }
        #endregion
    }
}
