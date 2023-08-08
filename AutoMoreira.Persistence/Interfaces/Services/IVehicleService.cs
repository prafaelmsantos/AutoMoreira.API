namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<VehicleDTO> AddVehicle(VehicleDTO vehicleDTO);
        Task<VehicleDTO> UpdateVehicle(int VehicleId, VehicleDTO vehicleDTO);
        Task<bool> DeleteVehicle(int vehicleId);

        Task<PageList<VehicleDTO>> GetAllVehiclesAsync(PageParams pageParams);
        Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId);
    }
}
