namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toName, string toAddress, string subject, string body);
    }
}
