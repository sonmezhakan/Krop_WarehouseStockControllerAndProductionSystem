using AutoMapper;
using Krop.Business.Features.Customers.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.CustomerHelpers
{
    public class CustomerHelper:ICustomerHelper
    {
        private readonly IWebApiService _webApiService;

        public CustomerHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public List<GetCustomerDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("customer/getall").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCustomerDTO>(response);

            return result.Data;
        }

        public List<GetCustomerComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("customer/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCustomerComboBoxDTO>(response);

            return result.Data;
        }

        public GetCustomerDTO GetByCustomerIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"customer/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetCustomerDTO>(response);

            return result.Data;
        }
    }
}
