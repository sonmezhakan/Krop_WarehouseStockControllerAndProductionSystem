using AutoMapper;
using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.CategoryHelpers
{
    internal class CategoryHelper:ICategoryHelper
    {
        private readonly IWebApiService _webApiService;
        private readonly IMapper _mapper;

        public CategoryHelper(IWebApiService webApiService,IMapper mapper)
        {
            _webApiService = webApiService;
            _mapper = mapper;
        }
        public async Task<List<GetCategoryComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetCategoryComboBoxDTO>(response);

            return _mapper.Map<List<GetCategoryComboBoxDTO>>(result.Data);
        }

        public async Task<List<GetCategoryDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/GetAll");

            await ResponseController.ErrorResponseController(response);

            var result =await ResponseController.SuccessDataListResponseController<GetCategoryDTO>(response);

            return _mapper.Map<List<GetCategoryDTO>>(result.Data);
        }

        public async Task<GetCategoryDTO> GetByCategoryIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"category/GetById/{Id}");
            
            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetCategoryDTO>(response);

            return _mapper.Map<GetCategoryDTO>(result.Data);
        }
    }
}
