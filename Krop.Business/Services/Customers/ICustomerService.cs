using Krop.Business.Features.Customers.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.Customers
{
    public interface ICustomerService
    {
        Task<IResult> AddAsync(CreateCustomerDTO createCustomerDTO);
        Task<IResult> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<GetCustomerDTO>>> GetAllAsync();
        Task<IDataResult<GetCustomerDTO>> GetByIdAsync(Guid id);
    }
}
