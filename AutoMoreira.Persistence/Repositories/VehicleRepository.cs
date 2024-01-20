namespace AutoMoreira.Persistence.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context) { }

        public async Task<PageList<Vehicle>> GetAllByPageParamsAsync(PageParams pageParams)
        {
            // Set<Vehicle>() or _context.Veihicles
            IQueryable<Vehicle> query = _context.Set<Vehicle>()
                .AsNoTracking()
                .Include(x => x.Model)
                .ThenInclude(x => x.Mark)
                .OrderBy(v => v.Id);

            return await PageList<Vehicle>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

    }
}
