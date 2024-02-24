namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailToUserAsync(string toName, string toAddress, string userName, string password);
        Task SendEmailToUpdatedUserAsync(string toName, string toAddress);
        Task SendEmailToClientAsync(string toName, string toAddress);
        Task SendEmailToUserNewPasswordAsync(string toName, string toAddress, string password);
    }
}
