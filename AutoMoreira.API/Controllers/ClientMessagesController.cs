namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMessagesController : ControllerBase
    {
        #region Properties

        private readonly IClientMessageService _clientMessageService;

        #endregion

        #region Constructors
        public ClientMessagesController(IClientMessageService clientMessageService)
        {
            _clientMessageService = clientMessageService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Client Messages
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientMessages = await _clientMessageService.GetAllClientMessagesAsync();
                if (clientMessages == null) return NoContent();

                return Ok(clientMessages);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar mensagens de clientes. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Client Message
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var clientMessage = await _clientMessageService.GetClientMessageByIdAsync(id);
                if (clientMessage == null) return NoContent();

                return Ok(clientMessage);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar a mensagem de cliente. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Client Message
        /// </summary>
        /// <param name="clientMessageDTO"></param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(ClientMessageDTO clientMessageDTO)
        {
            try
            {
                var clientMessage = await _clientMessageService.AddClientMessageAsync(clientMessageDTO);
                if (clientMessage == null) return NotFound("Erro ao tentar criar a mensagem de cliente!");

                return Ok(clientMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar a mensagem de cliente. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update Client Message Status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="id"></param>
        [HttpPut("Status/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateClientMessageStatus(int id, [FromBody] STATUS status)
        {
            try
            {
                ClientMessageDTO clientMessageDTO = await _clientMessageService.UpdateClientMessageStatusAsync(id, status);
                if (clientMessageDTO == null) return NoContent();

                return Ok(clientMessageDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o status da mensagem de cliente. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Client Messages
        /// </summary>
        /// <param name="clientMessagesIds"></param>
        [HttpPost("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromBody] List<int> clientMessagesIds)
        {
            return Ok(await _clientMessageService.DeleteClientMessagesAsync(clientMessagesIds));
        }
        #endregion
    }
}
