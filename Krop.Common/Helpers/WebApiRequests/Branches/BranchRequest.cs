using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Branches
{
    public class BranchRequest:IBranchRequest
    {
        private readonly IWebApiService _webApiService;

        public BranchRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateBranchDTO createBranchDTO) => await _webApiService.httpClient.PostAsJsonAsync("branch/add", createBranchDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateBranchDTO updateBranchDTO) => await _webApiService.httpClient.PutAsJsonAsync("branch/update", updateBranchDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"branch/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("branch/getall");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"branch/GetById/{id}");

    }
}
