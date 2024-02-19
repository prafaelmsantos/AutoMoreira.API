namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        #region Properties

        private readonly IVisitorService _visitorService;

        #endregion

        #region Constructors

        public VisitorsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get Line Chart
        /// </summary>
        [HttpGet("LineChart")]
        public async Task<IActionResult> GetLineChart()
        {
            try
            {
                var visitors = await _visitorService.GetAllVisitoresWithYearComparisonAsync();
                if (visitors == null) return NoContent();

                return Ok(visitors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar visitantes. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Get Bar Chart
        /// </summary>
        [HttpGet("BarChart")]
        public async Task<IActionResult> GetBarChart()
        {
            try
            {
                var visitors = await _visitorService.GetAllVisitoresWithMonthComparisonAsync();
                if (visitors == null) return NoContent();

                return Ok(visitors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar visitantes. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Get Counters
        /// </summary>
        [HttpGet("Counters")]
        public async Task<IActionResult> GetCounters()
        {
            try
            {
                var visitors = await _visitorService.GetAllVisitoresCountersAsync();
                if (visitors == null) return NoContent();

                return Ok(visitors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar visitantes. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create/Update Visitor
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var visitor = await _visitorService.CreateOrUpdateVisitorAsync();
                if (visitor == null) return NotFound("Erro ao criar/atualizar visitantes!");

                return Ok(visitor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao criar/atualizar visitantes. Erro: {ex.Message}");
            }
        }

        #endregion

    }
}
