using BusinessManagement.Models;

namespace BusinessManagement.Services
{
    public interface IEmailService
    {
        string GetTemplate(string type);
        Task Send(EmailModel emailModel);
    }
}
