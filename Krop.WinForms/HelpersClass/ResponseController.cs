using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Models;
using Krop.Common.Utilits.Result;

namespace Krop.WinForms.HelpersClass
{
    internal static class ResponseController
    {
        internal async static Task ErrorResponseController(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal async static Task<SuccessDataListResponseViewModel<T>> SuccessDataListResponseController<T>(HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode)
            {
                SuccessDataListResponseViewModel<T> successDataListResponseViewModel = await JsonHelper.DeserializeAsync<SuccessDataListResponseViewModel<T>>(response);

                return successDataListResponseViewModel;
            }

            return default;
        }
        internal async static Task<SuccessDataResponseViewModel<T>> SuccessDataResponseController<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                SuccessDataResponseViewModel<T> successDataResponseViewModel = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<T>>(response);

                return successDataResponseViewModel;
            }

            return default;
        }
    }
}
