using Krop.DTO.Dtos.AppUsers;

namespace Krop.Common.Helpers.WebApiRequests.AppUsers
{
    public interface IAppUserRequest
    {
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetByAppUserIdAsync(Guid id);

        Task<HttpResponseMessage> AddAsync(CreateAppUserDTO createAppUserDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateAppUserDTO updateAppUserDTO);
        Task<HttpResponseMessage> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO);

        Task<HttpResponseMessage> ConfirmationMailSender(Guid id);
        Task<HttpResponseMessage> ResetPasswordMailSender(Guid id);
    }
}
