namespace AutoMoreira.Persistence.Services
{
    public class ClientMessageService : IClientMessageService
    {
        private readonly IClientMessageRepository _clientMessageRepository;
        private readonly IMapper _mapper;

        public ClientMessageService(IClientMessageRepository clientMessageRepository, IMapper mapper)
        {
            _clientMessageRepository = clientMessageRepository;
            _mapper = mapper;
        }
        public async Task<ClientMessageDTO> AddClientMessageAsync(ClientMessageDTO clientMessageDTO)
        {
            try
            {
                ClientMessage clientMessage = _mapper.Map<ClientMessage>(clientMessageDTO);

                await _clientMessageRepository.AddAsync(clientMessage);

                return _mapper.Map<ClientMessageDTO>(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteClientMessage(int clientMessageId)
        {
            try
            {
                ClientMessage clientMessage = await _clientMessageRepository.FindByIdAsync(clientMessageId);

                if (clientMessage == null) throw new Exception("Mensagem de cliente não encontrada.");

                return await _clientMessageRepository.RemoveAsync(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClientMessageDTO>> GetAllClientMessagesAsync()
        {
            try
            {
                List<ClientMessage> clientMessages = await _clientMessageRepository.GetAll().ToListAsync();

                return _mapper.Map<List<ClientMessageDTO>>(clientMessages);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId)
        {
            try
            {
                ClientMessage clientMessage = await _clientMessageRepository.FindByIdAsync(clientMessageId);

                if (clientMessage == null) throw new Exception("Mensagem de cliente não encontrada.");

                return _mapper.Map<ClientMessageDTO>(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClientMessageDTO> UpdateClientMessageStatusAsync(ClientMessageUpdateStatusDTO clientMessageUpdateStatusDTO)
        {
            try
            {
                ClientMessage clientMessage = await _clientMessageRepository.FindByIdAsync(clientMessageUpdateStatusDTO.Id);

                if (clientMessage == null) throw new Exception("Mensagem de cliente não encontrada.");

                clientMessage.SetOpen(clientMessageUpdateStatusDTO.Open);

                await _clientMessageRepository.UpdateAsync(clientMessage);

                return _mapper.Map<ClientMessageDTO>(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar o status da mensagem de cliente. Erro: {ex.Message}");
            }
        }
    }
}
