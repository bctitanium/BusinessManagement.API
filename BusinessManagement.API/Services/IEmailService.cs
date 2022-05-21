using BusinessManagement.API.Models;

namespace BusinessManagement.API.Services
{
    public interface IEmailService
    {
        string GetTemplate(string type);
        Task Send(EmailModel emailModel);
    }
}
