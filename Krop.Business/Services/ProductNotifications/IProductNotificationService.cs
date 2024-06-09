using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.ProductNotifications;

namespace Krop.Business.Services.ProductNotifications
{
    public interface IProductNotificationService
    {
        Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetInAllAsync(Guid employeeId);
        Task<IDataResult<IEnumerable<GetProductNotificationListDTO>>> GetSentAllAsync(Guid employeeId);

        Task<IDataResult<GetProductNotificationDTO>> GetByIdAsync(Guid employeeId);
        Task<IResult> AddAsync(CreateProductNotificationDTO createProductNotificationDTO);
        Task<IResult> UpdateAsync(UpdateProductNotificationDTO updateProductNotificationDTO);
        Task<IResult> DeleteAsync(Guid id);

    }
}
