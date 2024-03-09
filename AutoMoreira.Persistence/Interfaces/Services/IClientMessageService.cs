namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IClientMessageService
    {
        Task<ClientMessageDTO> AddClientMessageAsync(ClientMessageDTO clientMessageDTO);
        Task<List<ResponseMessageDTO>> DeleteClientMessages(List<int> clientMessagesIds);

        Task<List<ClientMessageDTO>> GetAllClientMessagesAsync();
        Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId);
        Task<ClientMessageDTO> UpdateClientMessageStatusAsync(int id, STATUS status);
    }
}
