using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.ProductNotifications;

namespace Krop.Business.Services.ProductNotifications
{
    public interface IProductNotificationService
    {
        Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetInAllAsync(Guid inAppUserId);
        Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetSentAllAsync(Guid sentAppUserId);

        Task<IDataResult<GetProductNotificationDTO>> GetByIdAsync(Guid id, Guid appUserId);
        Task<IResult> AddAsync(CreateProductNotificationDTO createProductNotificationDTO);
        Task<IResult> UpdateAsync(UpdateProductNotificationDTO updateProductNotificationDTO);
        Task<IResult> DeleteAsync(Guid id,Guid appUserId);

    }
}
