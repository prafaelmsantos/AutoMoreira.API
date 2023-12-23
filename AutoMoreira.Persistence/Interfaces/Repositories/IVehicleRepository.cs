namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<PageList<Vehicle>> GetAllByPageParamsAsync(PageParams pageParams);
    }
}
