using AutoMapper;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Productions.Validations;
using Krop.Business.Features.ProductNotifications.Constants;
using Krop.Business.Features.ProductNotifications.Rules;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.ProductNotifications
{
    public partial class ProductNotificationManager : IProductNotificationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductNotificationRepository _productNotificationRepository;
        private readonly ProductNotificationBusinessRules _productNotificationBusinessRules;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly ICacheHelper _cacheHelper;

        public ProductNotificationManager(IMapper mapper,IUnitOfWork unitOfWork,IProductNotificationRepository productNotificationRepository,ProductNotificationBusinessRules productNotificationBusinessRules,EmployeeBusinessRules employeeBusinessRules,ICacheHelper cacheHelper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productNotificationRepository = productNotificationRepository;
            _productNotificationBusinessRules = productNotificationBusinessRules;
            _employeeBusinessRules = employeeBusinessRules;
            _cacheHelper = cacheHelper;
        }
        #region Add
        [ValidationAspect(typeof(CreateProductionValidator))]
        public async Task<IResult> AddAsync(CreateProductNotificationDTO createProductNotificationDTO)
        {
            var businessRule = BusinessRules.Run(await _employeeBusinessRules.CheckEmployeeWorkingAsync(createProductNotificationDTO.SenderAppUserId),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(createProductNotificationDTO.SentAppUserId),
                await _employeeBusinessRules.CheckEmployeeBranch(createProductNotificationDTO.SenderAppUserId, createProductNotificationDTO.BranchId),
                await _productNotificationBusinessRules.CheckNotificationSenderAndSentPersonSame(createProductNotificationDTO.SenderAppUserId, createProductNotificationDTO.SentAppUserId));
            if (!businessRule.Success)
                return businessRule;

            await _productNotificationRepository.AddAsync(
                _mapper.Map<ProductNotification>(createProductNotificationDTO));

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductNotificationCacheKeys.GetInAllAsync}{createProductNotificationDTO.SenderAppUserId}",
                $"{ProductNotificationCacheKeys.GetSentAllAsync}{createProductNotificationDTO.SentAppUserId}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateProductionValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductNotificationDTO updateProductNotificationDTO)
        {
            var result = await _productNotificationRepository.GetAsync(x => x.Id == updateProductNotificationDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductNotificationMessages.ProductNotificationNotFound);

            var businessRule = BusinessRules.Run(
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(updateProductNotificationDTO.SenderAppUserId),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(updateProductNotificationDTO.SentAppUserId),
                 await _employeeBusinessRules.CheckEmployeeBranch(updateProductNotificationDTO.SenderAppUserId, updateProductNotificationDTO.BranchId),
                await _productNotificationBusinessRules.CheckNotificationSenderAndSentPersonSame(updateProductNotificationDTO.SenderAppUserId, updateProductNotificationDTO.SentAppUserId));
            if (!businessRule.Success)
                return businessRule;

            ProductNotification productNotification = _mapper.Map(updateProductNotificationDTO, result);

            await _productNotificationRepository.UpdateAsync(productNotification);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductNotificationCacheKeys.GetInAllAsync}{updateProductNotificationDTO.SenderAppUserId}",
                $"{ProductNotificationCacheKeys.GetSentAllAsync}{updateProductNotificationDTO.SentAppUserId}",
                $"{ProductNotificationCacheKeys.GetByIdAsync}{updateProductNotificationDTO.Id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id,Guid appUserId)
        {
            var result = await _productNotificationRepository.GetAsync(x => x.Id == id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, ProductNotificationMessages.ProductNotificationNotFound);

            var businessRule = BusinessRules.Run(
                await _productNotificationBusinessRules.CheckPersonPerformingActionSamePersonTryingDelete(appUserId, result.SenderAppUserId),
                 await _employeeBusinessRules.CheckEmployeeBranch(result.BranchId, appUserId),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(appUserId));
            if(!businessRule.Success)
                return businessRule;

            await _productNotificationRepository.DeleteAsync(result);

            await _unitOfWork.SaveChangesAsync();

            await _cacheHelper.RemoveAsync(new string[]
            {
                $"{ProductNotificationCacheKeys.GetInAllAsync}{appUserId}",
                $"{ProductNotificationCacheKeys.GetSentAllAsync}{appUserId}",
                $"{ProductNotificationCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetInAllAsync(Guid inAppUserId)
        {
            IEnumerable<GetProductNotificationListDTO>? getProductNotificationListDTOs = await _cacheHelper.GetOrAddListAsync(
                $"{ProductNotificationCacheKeys.GetInAllAsync}{inAppUserId}",
                async () =>
                {
                    var result = await _productNotificationRepository.GetAllAsync(predicate: x => x.SentAppUserId == inAppUserId,
                    includeProperties: new Expression<Func<ProductNotification, object>>[]
                    {
                      p=>p.Product,
                      b=>b.Branch,
                      senderEmployee=>senderEmployee.SenderAppUser,
                      sentEmployee=>sentEmployee.SentAppUser,
                      s=>s.Product.Stocks
                    });

                    return result is null ? null : await ProductNotificationToGetProductNotificationListDTO(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(getProductNotificationListDTOs);
        }

        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetSentAllAsync(Guid sentAppUserId)
        {
            IEnumerable<GetProductNotificationListDTO>? getProductNotificationListDTOs = await _cacheHelper.GetOrAddListAsync(
                $"{ProductNotificationCacheKeys.GetSentAllAsync}{sentAppUserId}",
                async () =>
                {
                    var result = await _productNotificationRepository.GetAllAsync(predicate: x => x.SenderAppUserId == sentAppUserId,
                    includeProperties: new Expression<Func<ProductNotification, object>>[]
                    {
                       p=>p.Product,
                       b=>b.Branch,
                       senderEmployee=>senderEmployee.SenderAppUser,
                       sentEmployee=>sentEmployee.SentAppUser,
                      s=>s.Product.Stocks
                     });

                    return result is null ? null : await ProductNotificationToGetProductNotificationListDTO(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(getProductNotificationListDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductNotificationDTO>> GetByIdAsync(Guid id,Guid appUserId)
        {
            GetProductNotificationDTO? getProductNotificationDTO = await _cacheHelper.GetOrAddAsync(
                $"{ProductNotificationCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _productNotificationRepository.GetAsync(x => x.Id == id && (x.SenderAppUserId == appUserId || x.SentAppUserId == appUserId));

                    return result is null ? null : _mapper.Map<GetProductNotificationDTO>(result);
                },
                15
                );
                return getProductNotificationDTO is null ?
                new ErrorDataResult<GetProductNotificationDTO>(StatusCodes.Status404NotFound,ProductNotificationMessages.ProductNotificationNotFound):
                 new SuccessDataResult<GetProductNotificationDTO>(getProductNotificationDTO);
        }
        #endregion
    }

    #region Custom Metot
    public partial class ProductNotificationManager
    {
        private async Task<IEnumerable<GetProductNotificationListDTO>> ProductNotificationToGetProductNotificationListDTO(IEnumerable<ProductNotification> productNotifications)
        {
            List<GetProductNotificationListDTO> productNotification = new();
            foreach (var item in productNotifications)
            {
                productNotification.Add(new GetProductNotificationListDTO
                {
                    Id = item.Id,
                    SenderUserName = item.SenderAppUser.UserName,
                    SentUserName = item.SentAppUser.UserName,
                    BranchName = item.Branch.BranchName,
                    ProductName = item.Product.ProductName,
                    ProductCode = item.Product.ProductCode,
                    UnitsInStock = item.Product.Stocks.FirstOrDefault(x => x.BranchId == item.BranchId).UnitsInStock,
                    CriticalStock = item.Product.CriticalStock,
                    Description = item.Description,
                    SenderNotificationDate = item.SenderNotificationDate
                });
            }

            return productNotification.OrderByDescending(x => x.SenderNotificationDate);
        }
    }
    #endregion
}
