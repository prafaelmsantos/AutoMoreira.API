namespace AutoMoreira.Persistence.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _context;
        public ModelRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Model[]> GetAllModelsAsync()
        {
            IQueryable<Model> query = _context.Models;

            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Model> GetModelByIdAsync(int modelId)
        {
            IQueryable<Model> query = _context.Models;


            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == modelId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Model[]> GetModelsByMarkIdAsync(int markId)
        {
            IQueryable<Model> query = _context.Models;

            query = query.AsNoTracking().Where(x => x.Id == markId).OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

    }
}
