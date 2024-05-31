namespace AutoMoreira.Infrastructure.Services
{
    public class ClientMessageService : IClientMessageService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly IClientMessageRepository _clientMessageRepository;
        private readonly IEmailService _emailService;

        #endregion

        #region Constructors

        public ClientMessageService(IMapper mapper, IClientMessageRepository clientMessageRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _clientMessageRepository = clientMessageRepository;
            _emailService = emailService;
        }

        #endregion

        #region Public methods
        public async Task<List<ClientMessageDTO>> GetAllClientMessagesAsync()
        {
            try
            {
                List<ClientMessage> clientMessages = await _clientMessageRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<ClientMessageDTO>>(clientMessages);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllClientMessagesAsyncException} {ex.Message}");
            }
        }

        public async Task<ClientMessageDTO> GetClientMessageByIdAsync(int clientMessageId)
        {
            try
            {
                ClientMessage? clientMessage = await _clientMessageRepository.FindByIdAsync(clientMessageId);

                clientMessage.ThrowIfNull(() => throw new Exception(DomainResource.ClientMessageNotFoundException));

                return _mapper.Map<ClientMessageDTO>(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetClientMessageByIdAsyncException} {ex.Message}");
            }
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
                throw new Exception($"{DomainResource.AddClientMessageAsyncException} {ex.Message}");
            }
        }

        public async Task<ClientMessageDTO> UpdateClientMessageStatusAsync(int id, STATUS status)
        {
            try
            {
                ClientMessage? clientMessage = await _clientMessageRepository.FindByIdAsync(id);

                clientMessage.ThrowIfNull(() => throw new Exception(DomainResource.ClientMessageNotFoundException));

                clientMessage.SetStatus(status);

                await _clientMessageRepository.UpdateAsync(clientMessage);

                return _mapper.Map<ClientMessageDTO>(clientMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateClientMessageAsyncException} {ex.Message}");
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteClientMessagesAsync(List<int> clientMessagesIds)
        {
            return await DeleteAsync(clientMessagesIds);
        }

        #endregion

        #region Private methods

        private async Task<List<ResponseMessageDTO>> DeleteAsync(List<int> clientMessagesIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int clientMessagesId in clientMessagesIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = clientMessagesId }, OperationSuccess = false };
                try
                {
                    ClientMessage? clientMessage = await _clientMessageRepository.FindByIdAsync(clientMessagesId);

                    if (clientMessage is not null)
                    {
                        responseMessageDTO.Entity.Name = clientMessage.Name;
                        responseMessageDTO.OperationSuccess = await _clientMessageRepository.RemoveAsync(clientMessage);
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.ClientMessageNotFoundException;
                    }
                }
                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteClientMessagesAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}
