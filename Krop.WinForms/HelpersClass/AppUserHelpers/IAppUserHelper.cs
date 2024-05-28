using Krop.Business.Features.AppUsers.Dtos;

namespace Krop.WinForms.HelpersClass.AppUserHelpers
{
    public interface IAppUserHelper
    {
        List<GetAppUserComboBoxDTO> GetAllComboBoxAsync();
        List<GetAppUserDTO> GetAllAsync();
        GetAppUserDTO GetByAppUserIdAsync(Guid Id);
    }
}
