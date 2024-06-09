using AutoMapper;
using Krop.Business.Features.Productions.Validations;
using Krop.Business.Features.ProductNotifications.Rules;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.Entities.Entities;
using System.Linq.Expressions;

namespace Krop.Business.Services.ProductNotifications
{
    public class ProductNotificationManager : IProductNotificationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductNotificationRepository _productNotificationRepository;
        private readonly ProductNotificationBusinessRules _productNotificationBusinessRules;

        public ProductNotificationManager(IMapper mapper,IUnitOfWork unitOfWork,IProductNotificationRepository productNotificationRepository,ProductNotificationBusinessRules productNotificationBusinessRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productNotificationRepository = productNotificationRepository;
            _productNotificationBusinessRules = productNotificationBusinessRules;
        }
        #region Add
        [ValidationAspect(typeof(CreateProductionValidator))]
        public async Task<IResult> AddAsync(CreateProductNotificationDTO createProductNotificationDTO)
        {
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
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _productNotificationBusinessRules.CheckProductNotificationId(id);
            if (!result.Success)
                return result;

            await _productNotificationRepository.DeleteAsync(result.Data);

            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetInAllAsync(Guid inEmployeeId)
        {
            var result = await _productNotificationRepository.GetAllAsync(predicate:x=>x.SenderEmployeId == inEmployeeId,
                includeProperties: new Expression<Func<ProductNotification, object>>[]
                {
                    p=>p.Product,
                    b=>b.Branch,
                    senderEmployee=>senderEmployee.SenderEmployee.AppUser,
                    sentEmployee=>sentEmployee.SentEmployee.AppUser,
                    s=>s.Product.Stocks
                });

            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(
                _mapper.Map<IEnumerable<GetProductNotificationListDTO>>(result.OrderByDescending(x=>x.SenderNotificationDate).ToList()));
        }

        public async Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetSentAllAsync(Guid sentEmployeeId)
        {
            var result = await _productNotificationRepository.GetAllAsync(predicate: x => x.SentEmployeId == sentEmployeeId,
                 includeProperties: new Expression<Func<ProductNotification, object>>[]
                 {
                    p=>p.Product,
                    b=>b.Branch,
                    senderEmployee=>senderEmployee.SenderEmployee.AppUser,
                    sentEmployee=>sentEmployee.SentEmployee.AppUser,
                    s=>s.Product.Stocks
                 });

            return new SuccessDataResult<IEnumerable<GetProductNotificationListDTO>>(
                _mapper.Map<IEnumerable<GetProductNotificationListDTO>>(result.OrderByDescending(x => x.SenderNotificationDate).ToList()));
        }
        #endregion
        #region Search
        public Task<IDataResult<GetProductNotificationDTO>> GetByIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
