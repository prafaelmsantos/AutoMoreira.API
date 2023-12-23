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

        public async Task<VehicleDTO> AddVehicle(VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDTO);
                 await _vehicleRepository.AddAsync(vehicle);

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleDTO> UpdateVehicle(int vehicleId, VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.FindByIdAsync(vehicleId);

                if (vehicle == null) throw new Exception("Veiculo não encontrado.");

                vehicleDTO.Id = vehicle.Id;

                _mapper.Map(vehicleDTO, vehicle);

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

        public async Task<PageList<VehicleDTO>> GetAllVehiclesAsync(PageParams pageParams)
        {
            try
            {
                PageList<Vehicle> vehicles = await _vehicleRepository.GetAllByPageParamsAsync(pageParams);

                PageList<VehicleDTO> vehicleDTOs = _mapper.Map<PageList<VehicleDTO>>(vehicles);

                //Manual Mapper
                vehicleDTOs.CurrentPage = vehicles.CurrentPage;
                vehicleDTOs.TotalPages = vehicles.TotalPages;
                vehicleDTOs.PageSize = vehicles.PageSize;
                vehicleDTOs.TotalCount = vehicles.TotalCount;
                return vehicleDTOs;

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
                Vehicle vehicle = await _vehicleRepository.FindByIdAsync(vehicleId);

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
