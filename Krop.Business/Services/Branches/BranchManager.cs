using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Branches.Validations;
using Krop.Business.Services.Stocks;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Branches
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly IStockService _stockService;

        public BranchManager(IBranchRepository branchRepository, IMapper mapper, BranchBusinessRules branchBusinessRules, IStockService stockService)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _stockService = stockService;
        }

        #region Add
        [ValidationAspect(typeof(CreateBranchValidator))]
        public async Task<IResult> AddAsync(CreateBranchDTO createBranchDTO)
        {
            await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(createBranchDTO.BranchName);//BranchName Rule

            Branch branch = _mapper.Map<Branch>(createBranchDTO);
            branch.Stocks = await _stockService.NewBranchAddedProductAsync(branch.Id);//Stock dan gelen listesi branchin stocklarına aktarıyoruz.
            //todo:ürünleri ekleme işlemi yapılacak.
            await _branchRepository.AddAsync(branch);

            return new SuccessResult();
        }
        [ValidationAspect(typeof(CreateBranchValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateBranchDTO> createBranchDTOs)
        {
            createBranchDTOs.ForEach(async b =>
            {
                await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(b.BranchName);//BranchName Rule
            });

            List<Branch> branches = _mapper.Map<List<Branch>>(createBranchDTOs);

            //Şubelerde dönerek şubelerin stocks listesine gelen verileri ekliyor
            branches.ForEach(async b =>
            {
                b.Stocks = await _stockService.NewBranchAddedProductAsync(b.Id);
            });
            //todo:ürünleri stocka ekleme işlemi yapılacak.

            await _branchRepository.AddRangeAsync(branches);
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateBranchValidator))]
        public async Task<IResult> UpdateAsync(UpdateBranchDTO updateBranchDTO)
        {
            var branch = await _branchBusinessRules.CheckByBranchId(updateBranchDTO.Id);

            await _branchRepository.UpdateAsync(
                _mapper.Map(updateBranchDTO, branch));

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateBranchValidator))]
        public async Task<IResult> UpdateRangeAsync(List<UpdateBranchDTO> updateBranchDTOs)
        {
            updateBranchDTOs.ForEach(async b =>
            {
                await _branchBusinessRules.CheckByBranchId(b.Id);
            });

            await _branchRepository.UpdateRangeAsync(
                _mapper.Map<List<Branch>>(updateBranchDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var branch = await _branchBusinessRules.CheckByBranchId(id);

            await _stockService.BranchDeletedProductAsync(branch.Id);//Belirtilen şubeye ait stokdan ürünler sil.
            await _branchRepository.DeleteAsync(branch);//Şubeyi sil
            return new SuccessResult();
        }

        public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Branch> branches = new();

            ids.ForEach(async b =>
            {
                var branch = await _branchBusinessRules.CheckByBranchId(b);

                branches.Add(branch);
            });

            await _stockService.BranchDeletedRangeProductAsync(ids);//Belirtilen şubelere ait stokdan ürünler sil.
            await _branchRepository.DeleteRangeAsync(branches);//Şubeleri sil

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
            var branch = await _branchBusinessRules.CheckByBranchId(id);

            return new SuccessDataResult<GetBranchDTO>(
                _mapper.Map<GetBranchDTO>(branch));
        }
        #endregion


    }
}
