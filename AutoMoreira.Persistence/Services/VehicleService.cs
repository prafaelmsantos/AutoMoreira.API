namespace AutoMoreira.Persistence.Services
{
    public class VehicleService : IVehicleService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        #endregion

        #region Constructors
        public VehicleService(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;       
        }

        #endregion

        #region Public methods

        public async Task<List<VehicleDTO>> GetAllVehiclesAsync()
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository
                    .GetAll()
                    .Include(x => x.VehicleImages)
                    .Include(x => x.Model)
                    .ThenInclude(x => x.Mark)
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<VehicleDTO>>(vehicles);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllVehiclesAsyncException} {ex.Message}");
            }
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId)
        {
            try
            {
                Vehicle? vehicle = await _vehicleRepository
                    .GetAll()
                    .Where(x => x.Id == vehicleId)
                    .Include(x => x.VehicleImages)
                    .Include(x => x.Model)
                    .ThenInclude(x => x.Mark)
                    .FirstOrDefaultAsync();

                vehicle.ThrowIfNull(() => throw new Exception(DomainResource.VehicleNotFoundException));

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetVehicleByIdAsyncException} {ex.Message}");
            }
        }

        public async Task<VehicleCounterDTO> GetVehicleCountersAsync()
        {
            try
            {
                var salesVehiclesByMonth = await GetCountersValues(true, true);
                var salesVehicles = await GetCountersValues(true);
                var stockVehicles = await GetCountersValues();

                return new()
                {
                    TotalSalesMonth = new CounterDTO
                    {
                        Units = salesVehiclesByMonth.Item1,
                        Values = salesVehiclesByMonth.Item2
                    },
                    TotalSales = new CounterDTO
                    {
                        Units = salesVehicles.Item1,
                        Values = salesVehicles.Item2
                    },
                    TotalStock = new CounterDTO
                    {
                        Units = stockVehicles.Item1,
                        Values = stockVehicles.Item2
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetVehicleCountersAsyncException} {ex.Message}");
            }          
        }

        public async Task<ResponseCompleteStatisticDTO> GetAllVehiclesWithYearComparisonAsync()
        {
            try
            {
                List<StatisticDTO> currentStatisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year);
                List<StatisticDTO> lastStatisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year - 1);

                var values = GetValuesWithYearComparison(lastStatisticsDTO, currentStatisticsDTO);

                return new()
                {
                    Statistics = currentStatisticsDTO,
                    LastStatistics = lastStatisticsDTO,
                    Value = values.Item1,
                    ValuePerc =values.Item2
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllVehiclesWithYearComparisonAsyncException} {ex.Message}");
            }
        }

        public async Task<ResponseStatisticDTO> GetAllVehiclesWithMonthComparisonAsync()
        {
            try
            {
                List<StatisticDTO> statisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year);

                var values = GetValuesWithMonthComparison(statisticsDTO);

                return new()
                {
                    Statistics = statisticsDTO,
                    Value = values.Item1,
                    ValuePerc = values.Item2
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllVehiclesWithMonthComparisonAsyncException} {ex.Message}");
            }
        }

        public async Task<PieStatisticDTO> GetVehiclePieStatisticsAsync()
        {
            try
            {
                var pieValues = await GetPieStatisticValues();
                return new() { TotalSales = pieValues.Item1, TotalStock = pieValues.Item2 };
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetVehiclePieStatisticsAsyncException} {ex.Message}");
            }
        }

        public async Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = new(vehicleDTO.ModelId, vehicleDTO.Version, vehicleDTO.FuelType, vehicleDTO.Price, vehicleDTO.Mileage, 
                    vehicleDTO.Year, vehicleDTO.Color, vehicleDTO.Doors, vehicleDTO.Transmission, vehicleDTO.EngineSize, vehicleDTO.Power, 
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold, vehicleDTO.SoldDate);

                vehicle = SetVehicleImages(vehicleDTO, vehicle);

                await _vehicleRepository.AddAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.AddVehicleAsyncException} {ex.Message}");
            }
        }

        public async Task<VehicleDTO> UpdateVehicleAsync(VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle? vehicle = await _vehicleRepository
                    .GetAll()
                    .Where(x => x.Id == vehicleDTO.Id)
                    .Include(x => x.VehicleImages)
                    .FirstOrDefaultAsync();

                vehicle.ThrowIfNull(() => throw new Exception(DomainResource.VehicleNotFoundException));

                vehicle.Update(vehicleDTO.ModelId, vehicleDTO.Version, vehicleDTO.FuelType, vehicleDTO.Price, vehicleDTO.Mileage,
                    vehicleDTO.Year, vehicleDTO.Color, vehicleDTO.Doors, vehicleDTO.Transmission, vehicleDTO.EngineSize, vehicleDTO.Power,
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold, vehicleDTO.SoldDate);

                vehicle = SetVehicleImages(vehicleDTO, vehicle);

                await _vehicleRepository.UpdateAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateVehicleAsyncException} {ex.Message}");
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteVehiclesAsync(List<int> vehiclesIds)
        {
            return await DeleteVehicles(vehiclesIds);
        }

        #endregion

        #region Private methods

        private async Task<(int, double)> GetCountersValues(bool sold = false, bool byMonth = false)
        {
            var vehicles = await _vehicleRepository
                    .GetAll()
                    .Where(x => x.Sold == sold)
                    .ToListAsync();

            if (byMonth)
            {
                vehicles = vehicles.Where(x => x.SoldDate?.Month == DateTime.UtcNow.Month).ToList();
            }

            return (vehicles.Count(), vehicles.Select(x => x.Price).Sum());
        }

        private async Task<List<StatisticDTO>> GetStatisticsByYear(int year)
        {
            List<Vehicle> vehicles = await _vehicleRepository
                   .GetAll()
                   .Where(x => x.SoldDate!.Value.Year == year)
                   .ToListAsync();

            List<StatisticDTO> statisticsDTO = new();

            List<MONTH> monthList = Enum.GetValues(typeof(MONTH)).Cast<MONTH>().ToList();

            monthList.ForEach(month =>
                statisticsDTO.Add(new StatisticDTO()
                {
                    Month = month,
                    Year = year,
                    Value = vehicles.Where(x => x.Sold && x.SoldDate?.Month == (int)month).Select(x => x.Price).Sum()
                }));

            return statisticsDTO;
        }

        private static (double, double) GetValuesWithYearComparison(List<StatisticDTO> lastStatisticsDTO, List<StatisticDTO> currentStatisticsDTO)
        {
            double lastValue = lastStatisticsDTO.Select(x => x.Value).Sum();
            double currentValue = currentStatisticsDTO.Select(x => x.Value).Sum();
            double valuePerc = lastValue != 0 ? (double)(currentValue - lastValue) / lastValue * 100 : currentValue != 0 ? 100 : 0;

            return (currentValue, Math.Round(valuePerc, 1));
        }

        private static (double, double) GetValuesWithMonthComparison(List<StatisticDTO> statisticsDTO)
        {
            double currentMonthValue = statisticsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month)?.Select(x => x.Value)?.Sum() ?? 0;
            double lastMonthValue = statisticsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month - 1)?.Select(x => x.Value)?.Sum() ?? 0;
            double valuePerc = lastMonthValue != 0 ? (double)(currentMonthValue - lastMonthValue) / lastMonthValue * 100 : currentMonthValue != 0 ? 100 : 0;

            return (currentMonthValue, Math.Round(valuePerc, 1));
        }

        private async Task<(double, double)> GetPieStatisticValues()
        {
            List<Vehicle> vehicles = await _vehicleRepository
                   .GetAll()
                   .ToListAsync();

            int vehiclesSoldCount = vehicles.Where(x => x.Sold).Count();
            int vehiclesCount = vehicles.Where(x => !x.Sold).Count();
            double vehiclesSum = vehiclesSoldCount + vehiclesCount;

            double vehiclesSoldPerc = vehiclesSum != 0 ? (vehiclesSoldCount / vehiclesSum * 100) : 0;
            double vehiclesPerc = vehiclesSum != 0 ? (vehiclesCount / vehiclesSum * 100) : 0;

            return (Math.Round(vehiclesSoldPerc, 1), Math.Round(vehiclesPerc, 1));
        }

        private static Vehicle SetVehicleImages(VehicleDTO vehicleDTO, Vehicle vehicle)
        {
            List<VehicleImage> vehicleImages = new();
            vehicleDTO.VehicleImages.ForEach(x => vehicleImages.Add(new VehicleImage(x.Url)));
            vehicleImages.FirstOrDefault()?.SetIsMain();
            vehicle.SetVehicleImages(vehicleImages);

            return vehicle;
        }

        private async Task<List<ResponseMessageDTO>> DeleteVehicles(List<int> vehiclesIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int vehicleId in vehiclesIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = vehicleId }, OperationSuccess = false };
                try
                {
                    Vehicle? vehicle = await _vehicleRepository
                        .GetAll()
                        .Where(x => x.Id == vehicleId)
                        .Include(x => x.Model)
                        .ThenInclude(x => x.Mark)
                        .FirstOrDefaultAsync();

                    if (vehicle is not null)
                    {
                        responseMessageDTO.Entity.Name = $"{vehicle.Model.Mark.Name} {vehicle.Model.Name}" + vehicle.Version != null ? $" {vehicle.Version}" : String.Empty;
                        responseMessageDTO.OperationSuccess = await _vehicleRepository.RemoveAsync(vehicle);
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.ClientMessageNotFoundException;
                    }
                }
                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteClientMessagesAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}
