using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Models;

namespace Krop.WinForms.HelpersClass
{
    internal static class ResponseController
    {
        internal async static Task ErrorResponseController(HttpResponseMessage response)
        {
            ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
            MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal async static Task<SuccessDataResponseViewModel<T>> SuccessDataResponseController<T>(HttpResponseMessage response)
        {
            SuccessDataResponseViewModel<T> successDataResponseViewModel = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<T>>(response);

            return successDataResponseViewModel;
        }
    }
}
