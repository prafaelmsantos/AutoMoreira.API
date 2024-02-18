namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        #region Properties

        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _hostEnvironment;

        #endregion

        #region Constructors

        public VehiclesController(IVehicleService vehicleService, IWebHostEnvironment hostEnvironment)
        {
            _vehicleService = vehicleService;
            _hostEnvironment = hostEnvironment;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Vehicles
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehiclesAsync();
                if (vehicles == null) return NoContent();

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar veiculos. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Get Vehicle Counters
        /// </summary>
        [HttpGet("Counters")]
        public async Task<IActionResult> GetCounters()
        {
            try
            {
                var vehicles = await _vehicleService.GetCounters();
                if (vehicles == null) return NoContent();

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar veiculos. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Get Vehicle
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
                if (vehicle == null) return NoContent();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar o veiculo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Create Vehicle
        /// </summary>
        /// <param name="vehicleDTO"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                var vehicle = await _vehicleService.AddVehicleAsync(vehicleDTO);
                if (vehicle == null) return NoContent();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar criar o veiculo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Update Vehicle
        /// </summary>
        /// <param name="vehicleDTO"></param>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                var vehicle = await _vehicleService.UpdateVehicleAsync(vehicleDTO);
                if (vehicle == null) return NoContent();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o veiculo. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Delete Vehicle
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
                if (vehicle == null) return NoContent();

                if (await _vehicleService.DeleteVehicle(id))
                {
                    return Ok(new { message = "Veiculo apagado!" });
                }
                else
                {
                    throw new Exception("Veiculo não apagado!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar o veiculo. Erro: {ex.Message}");
            }
        }

        #endregion
    }
}
