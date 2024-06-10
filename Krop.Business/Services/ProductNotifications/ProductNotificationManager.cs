using AutoMapper;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Productions.Validations;
using Krop.Business.Features.ProductNotifications.Rules;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public ProductNotificationManager(IMapper mapper,IUnitOfWork unitOfWork,IProductNotificationRepository productNotificationRepository,ProductNotificationBusinessRules productNotificationBusinessRules,EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productNotificationRepository = productNotificationRepository;
            _productNotificationBusinessRules = productNotificationBusinessRules;
            _employeeBusinessRules = employeeBusinessRules;
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

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateProductionValidator))]
        public async Task<IResult> UpdateAsync(UpdateProductNotificationDTO updateProductNotificationDTO)
        {
            var businessRule = BusinessRules.Run(
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(updateProductNotificationDTO.SenderAppUserId),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(updateProductNotificationDTO.SentAppUserId),
                 await _employeeBusinessRules.CheckEmployeeBranch(updateProductNotificationDTO.SenderAppUserId, updateProductNotificationDTO.BranchId),
                await _productNotificationBusinessRules.CheckNotificationSenderAndSentPersonSame(updateProductNotificationDTO.SenderAppUserId, updateProductNotificationDTO.SentAppUserId));
            if (!businessRule.Success)
                return businessRule;

            var result = await _productNotificationBusinessRules.CheckProductNotificationId(updateProductNotificationDTO.Id);
            if (!result.Success)
                return result;

            ProductNotification productNotification = _mapper.Map(updateProductNotificationDTO, result.Data);

            await _productNotificationRepository.UpdateAsync(productNotification);

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id,Guid appUserId)
        {
            var result = await _productNotificationBusinessRules.CheckProductNotificationId(id);
            if (!result.Success)
                return result;

            var businessRule = BusinessRules.Run(
                await _productNotificationBusinessRules.CheckPersonPerformingActionSamePersonTryingDelete(appUserId, result.Data.SenderAppUserId),
                 await _employeeBusinessRules.CheckEmployeeBranch(result.Data.BranchId, appUserId),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(appUserId));
            if(!businessRule.Success)
                return businessRule;

            await _productNotificationRepository.DeleteAsync(result.Data);

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetInAllAsync(Guid inAppUserId)
        {
            var result = await _productNotificationRepository.GetAllAsync(predicate:x=>x.SentAppUserId == inAppUserId,
                includeProperties: new Expression<Func<ProductNotification, object>>[]
                {
                    p=>p.Product,
                    b=>b.Branch,
                    senderEmployee=>senderEmployee.SenderAppUser,
                    sentEmployee=>sentEmployee.SentAppUser,
                    s=>s.Product.Stocks
                });

            var productNotification = await ProductNotificationToGetProductNotificationListDTO(result);
        
            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(productNotification.OrderByDescending(x=>x.SenderNotificationDate));
        }

        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetSentAllAsync(Guid sentAppUserId)
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

            var productNotification = await ProductNotificationToGetProductNotificationListDTO(result);

            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(productNotification.OrderByDescending(x => x.SenderNotificationDate));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetProductNotificationDTO>> GetByIdAsync(Guid id)
        {
            var result = await _productNotificationBusinessRules.CheckProductNotificationId(id);
            if (!result.Success)
                return new ErrorDataResult<GetProductNotificationDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetProductNotificationDTO>(
                _mapper.Map<GetProductNotificationDTO>(result.Data));
        }
        #endregion
    }

    #region Custom Metot
    public partial class ProductNotificationManager
    {
        private async Task<List<GetProductNotificationListDTO>> ProductNotificationToGetProductNotificationListDTO(IEnumerable<ProductNotification> productNotifications)
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

            return productNotification;
        }
    }
    #endregion
}
