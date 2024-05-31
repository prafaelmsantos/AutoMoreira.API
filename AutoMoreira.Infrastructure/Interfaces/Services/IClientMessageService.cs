namespace AutoMoreira.Infrastructure.Interfaces.Services
{
    public interface IClientMessageService
    {
        Task<List<ClientMessageDTO>> GetAllClientMessagesAsync();
        Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId);
        Task<ClientMessageDTO> AddClientMessageAsync(ClientMessageDTO clientMessageDTO);
        Task<ClientMessageDTO> UpdateClientMessageStatusAsync(int id, STATUS status);
        Task<List<ResponseMessageDTO>> DeleteClientMessagesAsync(List<int> clientMessagesIds);
    }
}
