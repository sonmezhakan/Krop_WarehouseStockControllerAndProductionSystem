using AutoMapper;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.SupplierHelpers
{
    public class SupplierHelper : ISupplierHelper
    {
        private readonly IWebApiService _webApiService;

        public SupplierHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public List<GetSupplierDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("supplier/GetAll").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetSupplierDTO>(response);

            return result.Data;
        }

        public List<GetSupplierComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("supplier/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetSupplierComboBoxDTO>(response);

            return result.Data;
        }

        public GetSupplierDTO GetBySupplierIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"supplier/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetSupplierDTO>(response);

            return result.Data;
        }
    }
}
