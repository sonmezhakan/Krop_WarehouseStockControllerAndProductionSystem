using Krop.Business.Features.Brands.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.BrandHelpers
{
    internal class BrandHelper:IBrandHelper
    {
        private readonly IWebApiService _webApiService;

        public BrandHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public List<GetBrandDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("brand/getall").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBrandDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return result.Data;
        }

        public List<GetBrandComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("brand/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBrandComboBoxDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return result.Data;
        }
        public GetBrandDTO GetByBrandIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"brand/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetBrandDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return result.Data;
        }
    }
}
