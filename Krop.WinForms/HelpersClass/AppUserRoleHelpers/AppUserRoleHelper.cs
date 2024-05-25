using AutoMapper;
using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.AppUserRoleHelpers
{
    public class AppUserRoleHelper : IAppUserRoleHelper
    {
        private readonly IWebApiService _webApiService;

        public AppUserRoleHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<List<GetAppUserRoleDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("AppUserRole/GetAll");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetAppUserRoleDTO>(response);

            return result.Data ?? null;
        }

        public async Task<GetAppUserRoleDTO> GetByAppUserRoleIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"appUserRole/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetAppUserRoleDTO>(response);

            return result.Data ?? null;
        }
    }
}
