﻿namespace AutoMoreira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        #region Properties

        private readonly IVehicleService _vehicleService;

        #endregion

        #region Constructors

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
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
        /// Get Vehicles Line Chart
        /// </summary>
        [HttpGet("LineChart")]
        public async Task<IActionResult> GetLineChart()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVisitoresWithYearComparisonAsync();
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
        /// Get Vehicles Bar Chart
        /// </summary>
        [HttpGet("BarChart")]
        public async Task<IActionResult> GetBarChart()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehiclesWithMonthComparisonAsync();
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
        /// Get Counters
        /// </summary>
        [HttpGet("Counters")]
        public async Task<IActionResult> GetCounters()
        {
            try
            {
                var vehicles = await _vehicleService.GetVehicleCountersAsync();
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
        /// Get Pie Chart
        /// </summary>
        [HttpGet("PieChart")]
        public async Task<IActionResult> GetPieChart()
        {
            try
            {
                var vehicles = await _vehicleService.GetVehiclePieStatisticsAsync();
                if (vehicles == null) return NoContent();

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar as estatisticas dos veiculos. Erro: {ex.Message}");
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
                vehicleDTO.Id = id;
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

        //// <summary>
        /// Delete Vehicles
        /// </summary>
        /// <param name="vehiclesIds"></param>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> vehiclesIds)
        {
            return Ok(await _vehicleService.DeleteVehiclesAsync(vehiclesIds));
        }

        #endregion
    }
}
