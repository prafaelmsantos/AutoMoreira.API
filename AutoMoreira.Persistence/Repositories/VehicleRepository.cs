namespace AutoMoreira.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;
        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle[]> GetAllAsync()
        {
            IQueryable<Vehicle> query = _context.Vehicles;

            query = query
                .AsNoTracking()
                .OrderBy(v => v.Id)
                .Include(x => x.Mark)
                .Include(x => x.Model);

            return await query.ToArrayAsync();
        }


        public async Task<PageList<Vehicle>> GetAllVehiclesAsync(PageParams pageParams)
        {
            IQueryable<Vehicle> query = _context.Vehicles;

            query = query
                .AsNoTracking()
                .Include(x => x.Mark)
                .Include(y => y.Model)
                .OrderBy(v => v.Id);

            return await PageList<Vehicle>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            IQueryable<Vehicle> query = _context.Vehicles;


            query = query
                .AsNoTracking()
                .Include(x => x.Mark)
                .Include(y => y.Model)
                .OrderBy(p => p.Id)
                .Where(p => p.Id == vehicleId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}
