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
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold, vehicleDTO.SoldDate);

                vehicle = SetVehicleImages(vehicleDTO, vehicle);

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
                Vehicle? vehicle = await _vehicleRepository
                    .GetAll()
                    .Where(x=> x.Id == vehicleDTO.Id)
                    .Include( x=> x.VehicleImages)
                    .FirstOrDefaultAsync() ?? throw new Exception("Veiculo não encontrado.");
                
                vehicle.UpdateVehicle(vehicleDTO.ModelId, vehicleDTO.Version, vehicleDTO.FuelType, vehicleDTO.Price, vehicleDTO.Mileage,
                    vehicleDTO.Year, vehicleDTO.Color, vehicleDTO.Doors, vehicleDTO.Transmission, vehicleDTO.EngineSize, vehicleDTO.Power,
                    vehicleDTO.Observations, vehicleDTO.Opportunity, vehicleDTO.Sold, vehicleDTO.SoldDate);

                vehicle = SetVehicleImages(vehicleDTO, vehicle);

                await _vehicleRepository.UpdateAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteVehiclesAsync(List<int> vehiclesIds)
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
                        responseMessageDTO.Entity.Name = $"{vehicle.Model.Mark.Name} {vehicle.Model.Name} {vehicle.Version}";
                        
                        await _vehicleRepository.RemoveAsync(vehicle);                    
                        responseMessageDTO.OperationSuccess = true;
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = "Veiculo não encontrado.";
                    }
                }

                catch (Exception ex)
                {
                    responseMessageDTO.ErrorMessage = ex.Message;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

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
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId)
        {
            try
            {
                Vehicle? vehicle = await _vehicleRepository
                    .GetAll()
                    .Where( x=> x.Id == vehicleId)
                    .Include(x => x.VehicleImages)
                    .Include(x => x.Model)
                    .ThenInclude(x => x.Mark)
                    .FirstOrDefaultAsync();

                return vehicle == null ? throw new Exception("Veiculo não encontrado.") : _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleCounterDTO> GetVehicleCountersAsync()
        {
            var salesVehiclesByMonth = await GetCountersValues(true, true);
            var salesVehicles = await GetCountersValues(true);
            var stockVehicles = await GetCountersValues();

            return new VehicleCounterDTO
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

        public async Task<ResponseCompleteStatisticDTO> GetAllVisitoresWithYearComparisonAsync()
        {
            try
            {
                List<StatisticDTO> currentStatisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year);
                List<StatisticDTO> lastStatisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year - 1);

                double lastValue = lastStatisticsDTO.Select(x => x.Value).Sum();
                double currentValue = currentStatisticsDTO.Select(x => x.Value).Sum();
                double valuePerc = lastValue != 0 ? (double)(currentValue - lastValue) / lastValue * 100 : currentValue != 0 ? 100 : 0;

                return new ResponseCompleteStatisticDTO
                {
                    Statistics = currentStatisticsDTO,
                    LastStatistics = lastStatisticsDTO,
                    Value = currentValue,
                    ValuePerc = Math.Round(valuePerc, 1)

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseStatisticDTO> GetAllVehiclesWithMonthComparisonAsync()
        {
            try
            {
                List<StatisticDTO> statisticsDTO = await GetStatisticsByYear(DateTime.UtcNow.Year);

                double currentMonthValue = statisticsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month)?.Select(x => x.Value)?.Sum() ?? 0;
                double lastMonthValue = statisticsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month - 1)?.Select(x => x.Value)?.Sum() ?? 0;
                double valuePerc = lastMonthValue != 0 ? (double)(currentMonthValue - lastMonthValue) / lastMonthValue * 100 : currentMonthValue != 0 ? 100 : 0;

                return new ResponseStatisticDTO
                {
                    Statistics = statisticsDTO,
                    Value = currentMonthValue,
                    ValuePerc = Math.Round(valuePerc, 1)

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<PieStatisticDTO> GetVehiclePieStatisticsAsync()
        {
            try
            {
                var pieValues = await GetPieStatisticValues();
                return new PieStatisticDTO() { TotalSales = Math.Round(pieValues.Item1, 1), TotalStock = Math.Round(pieValues.Item2, 1)};
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

                if (byMonth)
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

        private async Task<List<StatisticDTO>> GetStatisticsByYear(int year)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<(double, double)> GetPieStatisticValues()
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository
                   .GetAll()
                   .ToListAsync();

                int vehiclesSoldCount = vehicles.Where(x => x.Sold).Count();
                int vehiclesCount = vehicles.Where(x => !x.Sold).Count();
                double vehiclesSum = vehiclesSoldCount + vehiclesCount;

                double vehiclesSoldPerc = vehiclesSum != 0 ? (vehiclesSoldCount / vehiclesSum * 100) : 0;
                double vehiclesPerc = vehiclesSum != 0 ? (vehiclesCount / vehiclesSum * 100) : 0;

                return (vehiclesSoldPerc, vehiclesPerc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static Vehicle SetVehicleImages(VehicleDTO vehicleDTO, Vehicle vehicle)
        {
            List<VehicleImage> vehicleImages = new();
            vehicleDTO.VehicleImages.ForEach(x => vehicleImages.Add(new VehicleImage(x.Url)));
            vehicleImages.FirstOrDefault()?.SetIsMain(true);
            vehicle.SetVehicleImages(vehicleImages);

            return vehicle;
        }

        #endregion
    }
}
