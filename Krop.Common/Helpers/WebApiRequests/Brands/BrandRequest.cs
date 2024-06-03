using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Brands
{
    public class BrandRequest:IBrandRequest
    {
        private readonly IWebApiService _webApiService;

        public BrandRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateBrandDTO createBrandDTO) => await _webApiService.httpClient.PostAsJsonAsync("brand/add", createBrandDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateBrandDTO updateBrandDTO) => await _webApiService.httpClient.PutAsJsonAsync("brand/update", updateBrandDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"brand/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("brand/getall");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("brand/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"brand/GetById/{id}");
    }
}
