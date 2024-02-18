using AutoMoreira.Core.Dto.ClientMessage;

namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IClientMessageService
    {
        Task<ClientMessageDTO> AddClientMessageAsync(ClientMessageDTO clientMessageDTO);
        Task<bool> DeleteClientMessage(int clientMessageId);

        Task<List<ClientMessageDTO>> GetAllClientMessagesAsync();
        Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId);
        Task<ClientMessageDTO> UpdateClientMessageStatusAsync(ClientMessageUpdateStatusDTO clientMessageUpdateStatusDTO);
    }
}
