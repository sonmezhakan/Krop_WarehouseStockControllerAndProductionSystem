using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;

namespace Krop.WinForms.HelpersClass.Categories
{
    internal static class CategoryCustomMetot
    {
        internal static async Task CategoryComboBoxList(ComboBox comboBox, IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("category/GetAllComboBox");

            if (!response.IsSuccessStatusCode)
            {
                ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SuccessResponseViewModel<GetCategoryComboBoxDTO> successDataResult = await JsonHelper.DeserializeAsync<SuccessResponseViewModel<GetCategoryComboBoxDTO>>(response);

            comboBox.DisplayMember = "categoryName";
            comboBox.ValueMember = "Id";

            comboBox.DataSource = successDataResult.Data;
        }
    }
}
