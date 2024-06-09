﻿using Krop.Business.Features.ProductNotifications.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
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

        public async Task<IDataResult<ProductNotification>> CheckProductNotificationId(Guid id)
        {
            var result = await _productNotificationRepository.GetAsync(x=>x.Id == id);
            if (result is null)
                return new ErrorDataResult<ProductNotification>(StatusCodes.Status404NotFound, ProductNotificationMessages.ProductNotificationNotFound);

            return new SuccessDataResult<ProductNotification>(result);
        }
    }
}
