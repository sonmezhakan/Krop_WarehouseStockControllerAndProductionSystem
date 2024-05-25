using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.BranchHelpers
{
    public class BranchHelper : IBranchHelper
    {
        private readonly IWebApiService _webApiService;
        private readonly IMapper _mapper;

        public BranchHelper(IWebApiService webApiService,IMapper mapper)
        {
            _webApiService = webApiService;
            _mapper = mapper;
        }
        public async Task<List<GetBranchDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/getall");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetBranchDTO>(response);

            return _mapper.Map<List<GetBranchDTO>>(result.Data);
        }

        public async Task<List<GetBranchComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataListResponseController<GetBranchComboBoxDTO>(response);

            return _mapper.Map<List<GetBranchComboBoxDTO>>(result.Data);
        }

        public async Task<GetBranchDTO> GetByBranchIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"branch/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);

            var result = await ResponseController.SuccessDataResponseController<GetBranchDTO>(response);

            return _mapper.Map<GetBranchDTO>(result.Data);
        }
    }
}
