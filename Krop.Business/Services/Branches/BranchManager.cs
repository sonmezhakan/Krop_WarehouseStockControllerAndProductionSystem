using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Business.Features.Branches.ExceptionHelper;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Services.Stocks;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.Branches
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly BranchBusinessRules _branchBusinessRules;
        private readonly BranchExceptionHelper _branchExceptionHelper;
        private readonly IStockService _stockService;

        public BranchManager(IBranchRepository branchRepository, IMapper mapper, BranchBusinessRules branchBusinessRules, BranchExceptionHelper branchExceptionHelper, IStockService stockService)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _branchBusinessRules = branchBusinessRules;
            _branchExceptionHelper = branchExceptionHelper;
            _stockService = stockService;
        }

        #region Add
        public async Task<bool> AddAsync(CreateBranchDTO createBranchDTO)
        {
            await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(createBranchDTO.BranchName);//BranchName Rule

            Branch branch = _mapper.Map<Branch>(createBranchDTO);
            branch.Stocks = await _stockService.NewBranchAddedProductAsync(branch.Id);//Stock dan gelen listesi branchin stocklarına aktarıyoruz.
            //todo:ürünleri ekleme işlemi yapılacak.
            return await _branchRepository.AddAsync(branch);
        }

        public async Task<bool> AddRangeAsync(List<CreateBranchDTO> createBranchDTOs)
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

            return await _branchRepository.AddRangeAsync(branches);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateBranchDTO updateBranchDTO)
        {
            Branch branch = await _branchRepository.FindAsync(updateBranchDTO.Id);
            if (branch is null)
                _branchExceptionHelper.ThrowBranchNotFound();

            branch = _mapper.Map(updateBranchDTO, branch);

            return await _branchRepository.UpdateAsync(branch);
        }

        public async Task<bool> UpdateRangeAsync(List<UpdateBranchDTO> updateBranchDTOs)
        {
            updateBranchDTOs.ForEach(async b =>
            {
                Branch branch = await _branchRepository.FindAsync(b.Id);
                if (branch is null)
                    _branchExceptionHelper.ThrowBranchNotFound();
            });

            List<Branch> branches = _mapper.Map<List<Branch>>(updateBranchDTOs);
            return await _branchRepository.UpdateRangeAsync(branches);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Branch branch = await _branchRepository.FindAsync(id);
            if (branch is null)
                _branchExceptionHelper.ThrowBranchNotFound();

            if (await _stockService.BranchDeletedProductAsync(branch.Id))//Belirtilen şubeye ait stokdan ürünler silinir ise şubeyi sil. 
                return await _branchRepository.DeleteAsync(branch);

            return false;
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            List<Branch> branches = new();

            ids.ForEach(async b =>
            {
                Branch branch = await _branchRepository.FindAsync(b);
                if (branch is null)
                    _branchExceptionHelper.ThrowBranchNotFound();

                branches.Add(branch);
            });

            if (await _stockService.BranchDeletedRangeProductAsync(ids))//Belirtilen şubelere ait stokdan ürünler silinir ise şubeleri sil.
                return await _branchRepository.DeleteRangeAsync(branches);

            return false;
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetBranchDTO>> GetAllAsync()
        {
            var result = await _branchRepository.GetAllAsync();

            List<GetBranchDTO> getBranchDTOs = _mapper.Map<List<GetBranchDTO>>(result);
            return getBranchDTOs;
        }
        #endregion
        #region Search
        public async Task<GetBranchDTO> GetByIdAsync(Guid id)
        {
            Branch branch = await _branchRepository.FindAsync(id);
            if (branch is null)
                _branchExceptionHelper.ThrowBranchNotFound();

            return _mapper.Map<GetBranchDTO>(branch);
        }
        #endregion


    }
}
