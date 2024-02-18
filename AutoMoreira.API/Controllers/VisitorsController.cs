using AutoMoreira.Core.Domains.Enum;

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
        /// Get All Visitors
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var visitors = await _visitorService.GetAllVisitoresAsync();
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
        public async Task<IActionResult> Post(MONTH month)
        {
            try
            {
                var visitor = await _visitorService.CreateOrUpdateVisitorAsync(month);
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
