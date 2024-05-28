using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Models;
using Krop.Common.Utilits.Result;

namespace Krop.WinForms.HelpersClass
{
    internal static class ResponseController
    {
        internal static void ErrorResponseController(HttpResponseMessage response)
        {
            ErrorResponseViewModel errorResponseViewModel = JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response).Result;
            MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static SuccessDataListResponseViewModel<T> SuccessDataListResponseController<T>(HttpResponseMessage response)
        {
            SuccessDataListResponseViewModel<T> successDataListResponseViewModel = JsonHelper.DeserializeAsync<SuccessDataListResponseViewModel<T>>(response).Result;

            return successDataListResponseViewModel;
        }
        internal static SuccessDataResponseViewModel<T> SuccessDataResponseController<T>(HttpResponseMessage response)
        {
            SuccessDataResponseViewModel<T> successDataResponseViewModel = JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<T>>(response).Result;

            return successDataResponseViewModel;
        }
    }
}
