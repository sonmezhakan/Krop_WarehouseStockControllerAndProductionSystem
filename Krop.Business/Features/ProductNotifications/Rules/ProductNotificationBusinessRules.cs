using Krop.Business.Features.ProductNotifications.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.ProductNotifications.Rules
{
    public class ProductNotificationBusinessRules
    {
        private readonly IProductNotificationRepository _productNotificationRepository;

        public ProductNotificationBusinessRules(IProductNotificationRepository productNotificationRepository)
        {
            _productNotificationRepository = productNotificationRepository;
        }
        public async Task<IResult> CheckNotificationSenderAndSentPersonSame(Guid senderAppUserId,Guid sentAppUserId)
        {
            if (senderAppUserId == sentAppUserId)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductNotificationMessages.NotificationSenderAndSentPersonCannotBeSameError);

            return new SuccessResult();
        }
        public async Task<IResult> CheckPersonPerformingActionSamePersonTryingDelete(Guid deleteAppUserId,Guid transactionAppUserId)
        {
            if (deleteAppUserId != transactionAppUserId)
                return new ErrorResult(StatusCodes.Status400BadRequest, ProductNotificationMessages.PersonPerformingActionSamePersonTryingDeleteError);

            return new SuccessResult();
        }
    }
}