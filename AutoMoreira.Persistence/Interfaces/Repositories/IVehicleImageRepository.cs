namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IVehicleImageRepository
    {
        Task<VehicleImage[]> GetAllVehicleImagesAsync();
        Task<VehicleImage> GetVehicleImageByIdAsync(int vehicleImageId);
        Task<VehicleImage[]> GetVehicleImagesByVehicleIdAsync(int vehicleId);
    }
}
