using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Productions;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Productions
{
    public class ProductionRequest:IProductionRequest
    {
        private readonly IWebApiService _webApiService;

        public ProductionRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateProductionDTO createProductionDTO) => await _webApiService.httpClient.PostAsJsonAsync("production/Add", createProductionDTO);

        public Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetAllAsync(Guid appUserId) => await _webApiService.httpClient.GetAsync($"production/getAll/{appUserId}");

        public Task<HttpResponseMessage> GetAllComboBoxAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateAsync(UpdateProductionDTO updateProductionDTO)
        {
            throw new NotImplementedException();
        }
    }
}
