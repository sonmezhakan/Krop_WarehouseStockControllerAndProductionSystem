using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.AppUserRoles
{
    public partial class AppUserRoleCheckedListBoxControl : UserControl
    {
        public AppUserRoleCheckedListBoxControl()
        {
            InitializeComponent();
        }
        public async Task AppUserRoleList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if(!response.IsSuccessStatusCode)
            {
               await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserRoleDTO>>(response);

            checkedListBox1.Items.Clear();
            foreach (var item in result.Data)
            {
                checkedListBox1.Items.Add(item.Name);
            }
        }
    }
}
