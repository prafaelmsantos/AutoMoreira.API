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
        public async Task<IActionResult> Post(ClientMessageDTO clientMessageDTO)
        {
            try
            {
                var clientMessage = await _clientMessageService.AddClientMessage(clientMessageDTO);
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
        /// Delete Client Message
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clientMessage = await _clientMessageService.GetClientMessageByIdAsync(id);
                if (clientMessage == null) return NoContent();

                if (await _clientMessageService.DeleteClientMessage(id))
                {

                    return Ok(new { message = "Mensagem de cliente não apagada!" });

                }
                else
                {
                    throw new Exception("Mensagem de cliente não apagada!");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar a mensagem de cliente. Erro: {ex.Message}");
            }
        }
        #endregion
    }
}
