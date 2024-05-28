using AutoMapper;
using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.CategoryHelpers
{
    internal class CategoryHelper:ICategoryHelper
    {
        private readonly IWebApiService _webApiService;

        public CategoryHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public List<GetCategoryComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("category/GetAllComboBox").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCategoryComboBoxDTO>(response);

            return result.Data;
        }

        public List<GetCategoryDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("category/GetAll").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result =ResponseController.SuccessDataListResponseController<GetCategoryDTO>(response);

            return result.Data;
        }

        public GetCategoryDTO GetByCategoryIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"category/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetCategoryDTO>(response);

            return result.Data;
        }
    }
}
