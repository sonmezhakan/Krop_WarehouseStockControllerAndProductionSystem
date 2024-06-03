using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.AppUsers
{
    public class AppUserRequest : IAppUserRequest
    {
        private readonly IWebApiService _webApiService;

        public AppUserRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateAppUserDTO createAppUserDTO) => await _webApiService.httpClient.PostAsJsonAsync("account/register", createAppUserDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateAppUserDTO updateAppUserDTO) => await _webApiService.httpClient.PutAsJsonAsync("account/update", updateAppUserDTO);
        public async Task<HttpResponseMessage> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO)=> await _webApiService.httpClient.PutAsJsonAsync("account/UpdatePassword", updateAppUserPasswordDTO);

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("account/getall");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync()=> await _webApiService.httpClient.GetAsync("account/getAllComboBox");

        public async Task<HttpResponseMessage> GetByAppUserIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"account/GetById/{id}");

        public async Task<HttpResponseMessage> ConfirmationMailSender(Guid id) => await _webApiService.httpClient.GetAsync($"account/ConfirmationMailSender/{id}");

        public async Task<HttpResponseMessage> ResetPasswordMailSender(Guid id) => await _webApiService.httpClient.GetAsync($"account/ResetPasswordMailSender/{id}");
    }
}
