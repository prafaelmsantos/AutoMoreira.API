namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO);
        Task<VehicleDTO> UpdateVehicleAsync(VehicleDTO vehicleDTO);
        Task<bool> DeleteVehicle(int vehicleId);

        Task<PageList<VehicleDTO>> GetAllVehiclesAsync(PageParams pageParams);
        Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId);
    }
}
