namespace AutoMoreira.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        #region Properties

        private readonly IModeloService _modeloService;

        #endregion


        #region Constructors

        public ModelosController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }
        #endregion

        #region CRUD Methods

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var modelos = await _modeloService.GetAllModelosAsync();
                if (modelos == null) return NoContent();

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar modelos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var veiculo = await _modeloService.GetModeloByIdAsync(id);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar modelos. Erro: {ex.Message}");
            }
        }
        [HttpGet("marca/{marcaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByMarcaId(int marcaId)
        {
            try
            {
                var modelos = await _modeloService.GetModeloByMarcaIdAsync(marcaId);
                if (modelos == null) return NoContent();

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar modelos por marcaId. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ModeloDTO model)
        {
            try
            {
                var veiculo = await _modeloService.AddModelos(model);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar modelos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModeloDTO model)
        {
            try
            {
                var veiculo = await _modeloService.UpdateModelo(id, model);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar modelos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
 
            try
            {
                var veiculo = await _modeloService.GetModeloByIdAsync(id);
                if (veiculo == null) return NoContent();

                if (await _modeloService.DeleteModelo(id))
                {
                    
                    return Ok(new { message = "Apagado" });

                }
                else
                {
                    throw new Exception("Modelo não apagado");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar modelos. Erro: {ex.Message}");
            }
        }

        #endregion

    }
}
