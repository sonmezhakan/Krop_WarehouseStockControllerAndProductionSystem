using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.BranchHelpers
{
    public class BranchHelper : IBranchHelper
    {
        private readonly IWebApiService _webApiService;

        public BranchHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public List<GetBranchDTO> GetAllAsync()
        {
            HttpResponseMessage response =  _webApiService.httpClient.GetAsync("branch/getall").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchDTO>(response);

            return result.Data;
        }

        public List<GetBranchComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("branch/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchComboBoxDTO>(response);

            return result.Data;
        }

        public GetBranchDTO GetByBranchIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"branch/GetById/{Id}").Result;

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetBranchDTO>(response);

            return result.Data;
        }
    }
}
