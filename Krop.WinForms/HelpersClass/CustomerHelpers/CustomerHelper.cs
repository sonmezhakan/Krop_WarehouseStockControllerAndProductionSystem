using AutoMapper;
using Krop.Business.Features.Customers.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.CustomerHelpers
{
    public class CustomerHelper:ICustomerHelper
    {
        private readonly IMapper _mapper;
        private readonly IWebApiService _webApiService;

        public CustomerHelper(IMapper mapper,IWebApiService webApiService)
        {
            _mapper = mapper;
            _webApiService = webApiService;
        }

        public async Task<List<GetCustomerDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("customer/getall");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetCustomerDTO>(response) ?? null;

            return _mapper.Map<List<GetCustomerDTO>>(result.Data);
        }

        public async Task<List<GetCustomerComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("customer/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetCustomerComboBoxDTO>(response);

            return _mapper.Map<List<GetCustomerComboBoxDTO>>(result.Data);
        }

        public async Task<GetCustomerDTO> GetByCustomerIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"customer/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetCustomerDTO>(response);

            return _mapper.Map<GetCustomerDTO>(result.Data);
        }
    }
}
