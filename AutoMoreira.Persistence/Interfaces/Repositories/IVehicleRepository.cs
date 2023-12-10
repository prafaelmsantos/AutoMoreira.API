namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task<PageList<Vehicle>> GetAllVehiclesAsync(PageParams pageParams);
        Task<Vehicle[]> GetAllAsync();
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
    }
}
