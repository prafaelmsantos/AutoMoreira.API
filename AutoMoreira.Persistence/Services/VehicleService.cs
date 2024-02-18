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

    }
}
