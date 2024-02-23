namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailToUserAsync(string toName, string toAddress, string userName, string password);
        Task SendEmailToClientAsync(string toName, string toAddress);
    }
}
