namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailToUserAsync(string toName, string toAddress, string userName, string password);
        Task SendEmailToUpdatedUserAsync(string toName, string toAddress);
        Task SendEmailToClientAsync(string toName, string toAddress);
        Task SendEmailToUserUpdatePasswordAsync(string toName, string toAddress, string password);
        Task SendEmailToUserResetPasswordAsync(string toName, string toAddress, string password);
    }
}
