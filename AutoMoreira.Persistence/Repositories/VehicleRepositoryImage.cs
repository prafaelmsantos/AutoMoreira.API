namespace AutoMoreira.Persistence.Repositories
{
    public class VehicleImageRepository : IVehicleImageRepository
    {
        private readonly AppDbContext _context;
        public VehicleImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleImage[]> GetAllAsync()
        {
            IQueryable<VehicleImage> query = _context.VehicleImages;

            query = query
                .AsNoTracking()
                .OrderBy(v => v.Id);

            return await query.ToArrayAsync();
        }

        public Task<VehicleImage[]> GetAllVehicleImagesAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<VehicleImage> GetVehicleImageByIdAsync(int vehicleImageId)
        {
            IQueryable<VehicleImage> query = _context.VehicleImages;


            query = query
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => p.Id == vehicleImageId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<VehicleImage[]> GetVehicleImagesByVehicleIdAsync(int vehicleId)
        {
            IQueryable<VehicleImage> query = _context.VehicleImages;

            query = query
                .AsNoTracking()
                .OrderBy(v => v.Id)
                .Where(p => p.VehicleId == vehicleId);

            return await query.ToArrayAsync();
        }
    }
}
