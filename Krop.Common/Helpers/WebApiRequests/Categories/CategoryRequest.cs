using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Categories
{
    public class CategoryRequest : ICategoryRequest
    {
        private readonly IWebApiService _webApiService;

        public CategoryRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateCategoryDTO createCategoryDTO) => await _webApiService.httpClient.PostAsJsonAsync("category/Add", createCategoryDTO);
        public async Task<HttpResponseMessage> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs) => await _webApiService.httpClient.PostAsJsonAsync("category/AddRange", createCategoryDTOs);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateCategoryDTO updateCategoryDTO) => await _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"category/Delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("category/GetAll");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("category/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"category/GetById/{id}");
 
    }
}
