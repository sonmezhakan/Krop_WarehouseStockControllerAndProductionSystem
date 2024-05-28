using Krop.Common.Models;

namespace Krop.Common.Helpers.EmailService
{
    public interface IEmailService
    {
        Task SendMailAsync(EmailViewModel emailViewModel);
    }
}
