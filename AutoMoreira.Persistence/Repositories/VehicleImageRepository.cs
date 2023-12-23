namespace AutoMoreira.Persistence.Repositories
{
    public class VehicleImageRepository : Repository<VehicleImage>, IVehicleImageRepository
    {
        public VehicleImageRepository(AppDbContext context) : base(context) { }
    }
}
