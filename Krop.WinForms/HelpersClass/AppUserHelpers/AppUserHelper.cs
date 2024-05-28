using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.AppUserHelpers
{
    public class AppUserHelper : IAppUserHelper
    {
        private readonly IWebApiService _webApiService;

        public AppUserHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public List<GetAppUserDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("account/getall").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserDTO>(response);

            return result.Data;
        }

        public List<GetAppUserComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("account/getAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserComboBoxDTO>(response);

            return result.Data;
        }

        public GetAppUserDTO GetByAppUserIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"account/GetById/{Id}").Result;

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var appUsers = ResponseController.SuccessDataResponseController<GetAppUserDTO>(response);

            return appUsers.Data;
        }
    }
}
