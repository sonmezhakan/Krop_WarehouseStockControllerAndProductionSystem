using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.AppUsers;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.ViewModel.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Calisan")]
    public class EmployeeController : Controller
    {
        private readonly IWebApiService _webApiService;

        public EmployeeController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("Employee/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetEmployeeListDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View(new CreateEmployeeVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                GetAppUserComboBoxDTOs = await AppUserSelectList()
            });
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateEmployeeVM createEmployeeVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("employee/add", createEmployeeVM.CreateEmployeeDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new CreateEmployeeVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                    GetAppUserComboBoxDTOs = await AppUserSelectList()
                });
            }
            TempData["Success"] = "Çalışan Ekleme İşlemi Başarılı!";
            return View(new CreateEmployeeVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                GetAppUserComboBoxDTOs = await AppUserSelectList(),
                CreateEmployeeDTO = createEmployeeVM.CreateEmployeeDTO
            });
        }
        [HttpGet("Guncelle/{appUserId?}")]
        public async Task<IActionResult> Update(Guid? appUserId)
        {
            if(appUserId != null && appUserId != Guid.Empty)
            {
                HttpResponseMessage response = await GetById((Guid)appUserId);
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateEmployeeVM
                    {
                        GetBranchComboBoxDTOs = await BranchSelectList(),
                        GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                        GetEmployeeComboBoxDTOs = await EmployeeSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateEmployeeDTO>>(response);
                return View(new UpdateEmployeeVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                    GetEmployeeComboBoxDTOs = await EmployeeSelectList(),
                    UpdateEmployeeDTO = resultSuccess.Data
                });
            }
            return View(new UpdateEmployeeVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                GetEmployeeComboBoxDTOs = await EmployeeSelectList()
            });
        }
        [HttpPost("Guncelle/{appUserId?}")]
        public async Task<IActionResult> Update(UpdateEmployeeVM updateEmployeeVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("employee/update", updateEmployeeVM.UpdateEmployeeDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateEmployeeVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetDepartmentComboBoxDTOs = await DepartmentSelectList(),
                    GetEmployeeComboBoxDTOs = await EmployeeSelectList(),
                    UpdateEmployeeDTO = updateEmployeeVM.UpdateEmployeeDTO
                });
            }
            TempData["Success"] = "Çalışan Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "Employee", new { appUserId = updateEmployeeVM.UpdateEmployeeDTO.AppUserId });
        }
        private async Task<List<GetAppUserComboBoxDTO>> AppUserSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("Account/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<List<GetEmployeeComboBoxDTO>> EmployeeSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("employee/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetEmployeeComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<List<GetDepartmentComboBoxDTO>> DepartmentSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/getallCombobox");
            if(!response.IsSuccessStatusCode) 
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetDepartmentComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async  Task<List<GetBranchComboBoxDTO>> BranchSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBranchComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid appUserId) => await _webApiService.httpClient.GetAsync($"employee/GetById/{appUserId}");
    }
}
