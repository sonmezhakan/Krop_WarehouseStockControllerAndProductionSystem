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
        public List<GetAppUserRoleDTO> GetAllAsync()
        {
            HttpResponseMessage response =  _webApiService.httpClient.GetAsync("AppUserRole/GetAll").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserRoleDTO>(response);

            return result.Data ?? null;
        }

        public  GetAppUserRoleDTO GetByAppUserRoleIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"appUserRole/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetAppUserRoleDTO>(response);

            return result.Data ?? null;
        }
    }
}
