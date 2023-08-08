namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task<PageList<Vehicle>> GetAllVehiclesAsync(PageParams pageParams);
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
    }
}
