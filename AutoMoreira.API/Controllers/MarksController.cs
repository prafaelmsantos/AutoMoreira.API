namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        #region Properties

        private readonly IMarkService _markService;

        #endregion

        #region Constructors

        public MarksController(IMarkService markService)
        {
            _markService = markService;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Marks
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marks = await _markService.GetAllMarksAsync();
                if (marks == null) return NoContent();

                return Ok(marks);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar marcas. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Mark
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var mark = await _markService.GetMarkByIdAsync(id);
                if (mark == null) return NoContent();



                return Ok(mark);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar a marca. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Mark
        /// </summary>
        /// <param name="markDTO"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarkDTO markDTO)
        {
            try
            {
                var mark = await _markService.AddMarkAsync(markDTO);
                if (mark == null) return NotFound("Erro a criar a marca!");

                return Ok(mark);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar a marca. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Update Mark
        /// </summary>
        /// <param name="id"></param>
        /// <param name="markDTO"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MarkDTO markDTO)
        {
            try
            {
                markDTO.Id = id;
                var mark = await _markService.UpdateMarkAsync(markDTO);
                if (mark == null) return NoContent();

                return Ok(mark);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a marca. Erro: {ex.Message}");
            }
        }


        //// <summary>
        /// Delete Marks
        /// </summary>
        /// <param name="modelsIds"></param>
        [HttpPost("DeleteMarks")]
        public async Task<IActionResult> Delete([FromBody] List<int> marksIds)
        {
            return Ok(await _markService.DeleteMarksAsync(marksIds));
        }
        #endregion

    }
}
