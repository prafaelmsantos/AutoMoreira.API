namespace AutoMoreira.Persistence.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = new(vehicleDTO.ModelId, vehicleDTO.Version, vehicleDTO.FuelType, vehicleDTO.Price, vehicleDTO.Mileage, 
                    vehicleDTO.Year, vehicleDTO.Color, vehicleDTO.Doors, vehicleDTO.Transmission, vehicleDTO.EngineSize, vehicleDTO.Power, 
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold);

                 await _vehicleRepository.AddAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleDTO> UpdateVehicleAsync(VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.FindByIdAsync(vehicleDTO.Id);

                if (vehicle == null) throw new Exception("Veiculo não encontrado.");

                vehicle.UpdateVehicle(vehicleDTO.ModelId, vehicleDTO.Version, vehicleDTO.FuelType, vehicleDTO.Price, vehicleDTO.Mileage,
                    vehicleDTO.Year, vehicleDTO.Color, vehicleDTO.Doors, vehicleDTO.Transmission, vehicleDTO.EngineSize, vehicleDTO.Power,
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold);

                await _vehicleRepository.UpdateAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVehicle(int vehicleId)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.FindByIdAsync(vehicleId);

                if (vehicle == null) throw new Exception("Veiculo não encontrado.");

                return await _vehicleRepository.RemoveAsync(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<VehicleDTO>> GetAllVehiclesAsync()
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<VehicleDTO>>(vehicles);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository
                    .GetAll()
                    .Where( x=> x.Id == vehicleId)
                    .Include(x => x.Model)
                    .ThenInclude(x => x.Mark)
                    .FirstOrDefaultAsync();

                if (vehicle == null) throw new Exception("Veiculo não encontrado.");

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleCounterDTO> GetVehicleCountersAsync()
        {
            var soldVehiclesByMonth = await GetCountersValues(true, true);
            var soldVehicles = await GetCountersValues(true);
            var stockVehicles = await GetCountersValues();

            return new VehicleCounterDTO
            {
                Month = new SoldVehicleDTO
                {
                    Units = soldVehiclesByMonth.Item1,
                    Values = soldVehiclesByMonth.Item2
                },
                Total = new SoldVehicleDTO
                {
                    Units = soldVehicles.Item1,
                    Values = soldVehicles.Item2
                },
                StockVehiclesUnits = stockVehicles.Item1,
                StockVehiclesValues = stockVehicles.Item2,
                
            };

        }

        public async Task<List<StatisticDTO>> GetVehicleStatisticsAsync(int? year)
        {
            try
            {
                return await GetStatisticValues(year);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CircularStatisticDTO> GetVehicleCircularStatisticsAsync()
        {
            try
            {
                var circularValues = await GetCircularStatisticValues();
                return new CircularStatisticDTO() { SoldVehiclesUnits = circularValues.Item1, StockVehiclesUnits = circularValues.Item2 };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Private methods

        private async Task<(int, double)> GetCountersValues(bool sold = false, bool byMonth = false)
        {
            try
            {
                var vehicles = await _vehicleRepository
                    .GetAll()
                    .Where(x=> x.Sold == sold)
                    .ToListAsync();

                if (byMonth is true)
                {
                    vehicles = vehicles.Where(x => x.SoldDate?.Month == DateTime.UtcNow.Month).ToList();
                }

                return (vehicles.Count(), vehicles.Select(x => x.Price).Sum());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<StatisticDTO>> GetStatisticValues(int? year)
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository
                   .GetAll()
                   .Where(x => x.SoldDate.Value.Year == (year ?? DateTime.UtcNow.Year))
                   .ToListAsync();

                List<VehicleDTO> vehiclesDTO = _mapper.Map<List<VehicleDTO>>(vehicles);

                List<MONTH> monthList = Enum.GetValues(typeof(MONTH)).Cast<MONTH>().ToList();
                List<StatisticDTO> statisticsDTO = new();

                monthList.ForEach(month =>
                    statisticsDTO.Add(new StatisticDTO() { Month = month, Value = vehiclesDTO.Where(x => x.SoldDate?.Month == (int)month).Select(x => x.Price).Sum() }));

                return statisticsDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<(int, int)> GetCircularStatisticValues()
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository
                   .GetAll()
                   .ToListAsync();

                return (vehicles.Where( x=> x.Sold).Count(), vehicles.Where(x => !x.Sold).Count());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
