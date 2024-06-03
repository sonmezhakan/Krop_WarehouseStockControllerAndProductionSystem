using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.AppUserRoles
{
    public class AppUserRoleRequest:IAppUserRoleRequest
    {
        private readonly IWebApiService _webApiService;

        public AppUserRoleRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO) => await _webApiService.httpClient.PostAsJsonAsync("appUserRole/Add", createAppUserRoleDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO) => await _webApiService.httpClient.PutAsJsonAsync("appUserRole/update", updateAppUserRoleDTO);
        public Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("AppUserRole/GetAll");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"appUserRole/GetById/{id}");
    }
}
