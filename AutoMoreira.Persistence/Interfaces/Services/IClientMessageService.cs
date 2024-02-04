namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IClientMessageService
    {
        Task<ClientMessageDTO> AddClientMessage(ClientMessageDTO clientMessageDTO);
        Task<bool> DeleteClientMessage(int clientMessageId);

        Task<List<ClientMessageDTO>> GetAllClientMessagesAsync();
        Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId);
    }
}
