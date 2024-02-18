namespace AutoMoreira.Persistence.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context) { }
    }
}
