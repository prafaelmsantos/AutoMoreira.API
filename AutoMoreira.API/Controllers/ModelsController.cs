using AutoMoreira.Core.Dto;

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
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _modelService.GetAllModelsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Get Model
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _modelService.GetModelByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Get Models by Mark
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("Mark/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByMarkId([FromRoute] int id)
        {
            try
            {
                return Ok(await _modelService.GetModelsByMarkIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Create Model
        /// </summary>
        /// <param name="modelDTO"></param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] ModelDTO modelDTO)
        {
            try
            {
                modelDTO.Id = 0;
                return Ok(await _modelService.AddModelAsync(modelDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelDTO></param>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ModelDTO modelDTO)
        {
            try
            {
                modelDTO.Id = id;
                return Ok(await _modelService.UpdateModelAsync(modelDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        //// <summary>
        /// Delete Models
        /// </summary>
        /// <param name="modelsIds"></param>
        [HttpPost("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromBody] List<int> modelsIds)
        {
            try
            {
                return Ok(await _modelService.DeleteModelsAsync(modelsIds));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            } 
        }

        #endregion
    }
}
