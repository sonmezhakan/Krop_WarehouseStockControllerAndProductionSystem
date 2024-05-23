using AutoMapper;
using Krop.Business.Features.Brands.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.BrandHelpers
{
    internal class BrandHelper:IBrandHelper
    {
        private readonly IWebApiService _webApiService;
        private readonly IMapper _mapper;

        public BrandHelper(IWebApiService webApiService,IMapper mapper)
        {
            _webApiService = webApiService;
            _mapper = mapper;
        }

        public async Task<List<GetBrandDTO>> GetAllAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/getall");

            await ResponseController.ErrorResponseController(response);//response hata kontrolü

            var result = await ResponseController.SuccessDataListResponseController<GetBrandDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return _mapper.Map<List<GetBrandDTO>>(result.Data);
        }

        public async Task<List<GetBrandComboBoxDTO>> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/GetAllComboBox");

            await ResponseController.ErrorResponseController(response);//response hata kontrolü

            var result = await ResponseController.SuccessDataListResponseController<GetBrandComboBoxDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return _mapper.Map<List<GetBrandComboBoxDTO>>(result.Data);
        }
        public async Task<GetBrandDTO> GetByBrandIdAsync(Guid Id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"brand/GetById/{Id}");

            await ResponseController.ErrorResponseController(response);//response hata kontrolü

            var result = await ResponseController.SuccessDataResponseController<GetBrandDTO>(response);//response başarılı durumunda geriye dönen cevabı modelliyoruz.

            return _mapper.Map<GetBrandDTO>(result.Data);
        }
    }
}
