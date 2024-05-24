using AutoMapper;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.SupplierHelpers
{
    public class SupplierHelper : ISupplierHelper
    {
        private readonly IWebApiService _webApiService;
        private readonly IMapper _mapper;

        public SupplierHelper(IWebApiService webApiService,IMapper mapper)
        {
            _webApiService = webApiService;
            _mapper = mapper;
        }
        public async Task<List<GetSupplierDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAll");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetSupplierDTO>(response);

            return _mapper.Map<List<GetSupplierDTO>>(result.Data);
        }

        public async Task<List<GetSupplierComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetSupplierComboBoxDTO>(response);

            return _mapper.Map<List<GetSupplierComboBoxDTO>>(result.Data);
        }

        public async Task<GetSupplierDTO> GetBySupplierIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"supplier/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetSupplierDTO>(response);

            return _mapper.Map<GetSupplierDTO>(result.Data);
        }
    }
}
