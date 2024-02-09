namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        #region Properties

        private readonly IModelService _modelService;

        #endregion


        #region Constructors

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Models
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var models = await _modelService.GetAllModelsAsync();
                if (models == null) return NoContent();

                return Ok(models);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar modelos. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Model
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await _modelService.GetModelByIdAsync(id);
                if (model == null) return NoContent();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar o modelo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Models by Mark
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("Mark/{id}")]
        public async Task<IActionResult> GetByMarkId(int id)
        {
            try
            {
                var models = await _modelService.GetModelsByMarkIdAsync(id);
                if (models == null) return NoContent();

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar modelos por marca id. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Model
        /// </summary>
        /// <param name="modelDTO"></param>
        [HttpPost]
        public async Task<IActionResult> Post(ModelDTO modelDTO)
        {
            try
            {
                var model = await _modelService.AddModel(modelDTO);
                if (model == null) return NoContent();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar o modelo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelDTO></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModelDTO modelDTO)
        {
            try
            {
                var model = await _modelService.UpdateModel(id, modelDTO);
                if (model == null) return NoContent();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o modelo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Delete Model
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
 
            try
            {
                var model = await _modelService.GetModelByIdAsync(id);
                if (model == null) return NoContent();

                if (await _modelService.DeleteModel(id))
                {
                    
                    return Ok(new { message = "Modelo apagado!" });

                }
                else
                {
                    throw new Exception("Modelo não apagado!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar o modelo. Erro: {ex.Message}");
            }
        }

        #endregion

    }
}
