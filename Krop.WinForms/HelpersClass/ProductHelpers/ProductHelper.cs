using Krop.Business.Features.Products.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.ProductHelpers
{
    public class ProductHelper : IProductHelper
    {
        private readonly IWebApiService _webApiService;

        public ProductHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<List<GetProductComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetProductComboBoxDTO>(response);

            return result.Data;
        }

        public async Task<GetProductDTO> GetProductByIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetProductDTO>(response);

            return result.Data;
        }
    }
}
