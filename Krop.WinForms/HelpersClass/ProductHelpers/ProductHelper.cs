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

        public List<GetProductListDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("product/GetAll").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductListDTO>(response);

            return result.Data;
        }

        public List<GetProductComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("product/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductComboBoxDTO>(response);

            return result.Data;
        }

        public GetProductDTO GetByProductIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"product/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetProductDTO>(response);

            return result.Data;
        }

        public GetProductCartDTO GetByProductIdCartAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"product/GetByIdCart/{Id}").Result;

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetProductCartDTO>(response);

            return result.Data;
        }
    }
}
