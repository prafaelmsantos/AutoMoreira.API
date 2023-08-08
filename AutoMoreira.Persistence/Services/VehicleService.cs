using AutoMoreira.Core.Domains;

namespace AutoMoreira.Persistence.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(
        IBaseRepository baseRepository,
        IVehicleRepository vehicleRepository,
        IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<VehicleDTO> AddVehicle(VehicleDTO vehicleDTO)
        {

            try
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
                _baseRepository.Add<Vehicle>(vehicle);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _vehicleRepository.GetVehicleByIdAsync(vehicle.Id);
                    return _mapper.Map<VehicleDTO>(result);
                }
                return null;
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
                var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
                if (vehicle == null) return null;

                vehicleDTO.Id = vehicle.Id;

                _mapper.Map(vehicleDTO, vehicle);

                _baseRepository.Update<Vehicle>(vehicle);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _vehicleRepository.GetVehicleByIdAsync(vehicle.Id);
                    return _mapper.Map<VehicleDTO>(result);
                }
                return null;
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
                var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
                if (vehicle == null) throw new Exception("Veiculo não encontrado.");

                _baseRepository.Delete<Vehicle>(vehicle);
                return await _baseRepository.SaveChangesAsync();
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
                var vehicles = await _vehicleRepository.GetAllVehiclesAsync(pageParams);
                if (vehicles == null) return null;

                var result = _mapper.Map<PageList<VehicleDTO>>(vehicles);

                //Manual Mapper
                result.CurrentPage = vehicles.CurrentPage;
                result.TotalPages = vehicles.TotalPages;
                result.PageSize = vehicles.PageSize;
                result.TotalCount = vehicles.TotalCount;
                return  result;

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
                var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
                if (vehicle == null) return null;

                return _mapper.Map<VehicleDTO>(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
