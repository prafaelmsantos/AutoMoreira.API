namespace AutoMoreira.API.Controllers
{
    [Authorize]
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

        [HttpGet]
        [AllowAnonymous]
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


        [HttpGet("{id}")]
        [AllowAnonymous]
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


        [HttpPost]
        public async Task<IActionResult> Post(MarkDTO markDTO)
        {
            try
            {
                var mark = await _markService.AddMark(markDTO);
                if (mark == null) return NotFound("Erro a criar a marca!");

                return Ok(mark);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar a marca. Erro: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MarkDTO markDTO)
        {
            try
            {
                var mark = await _markService.UpdateMark(id, markDTO);
                if (mark == null) return NoContent();

                return Ok(mark);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a marca. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mark = await _markService.GetMarkByIdAsync(id);
                if (mark == null) return NoContent();

                if (await _markService.DeleteMark(id))
                {
                  
                   return Ok(new { message = "Marca apagada!" });

                }
                else
                {
                    throw new Exception("Marca não apagada!");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar a marca. Erro: {ex.Message}");
            }
        }
        #endregion

    }
}
