namespace AutoMoreira.Persistence.Services
{
    public class ClientMessageService : IClientMessageService
    {
        private readonly IClientMessageRepository _clientMessageRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public ClientMessageService(IClientMessageRepository clientMessageRepository, IMapper mapper, IEmailService emailService)
        {
            _clientMessageRepository = clientMessageRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<ClientMessageDTO> AddClientMessageAsync(ClientMessageDTO clientMessageDTO)
        {
            try
            {
                ClientMessage clientMessage = new(clientMessageDTO.Name, clientMessageDTO.Email, clientMessageDTO.PhoneNumber, clientMessageDTO.Message);

                await _clientMessageRepository.AddAsync(clientMessage);

                await _emailService.SendEmailToClientAsync(clientMessageDTO.Name, clientMessageDTO.Email);

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
                List<ClientMessage> clientMessages = await _clientMessageRepository.GetAll().OrderBy(x => x.Id).ToListAsync();

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

        public async Task<ClientMessageDTO> UpdateClientMessageStatusAsync(int id, STATUS status)
        {
            try
            {
                ClientMessage clientMessage = await _clientMessageRepository.FindByIdAsync(id);

                if (clientMessage is null) throw new Exception("Mensagem de cliente não encontrada.");

                clientMessage.SetStatus(status);

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
