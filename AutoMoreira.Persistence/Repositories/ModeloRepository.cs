namespace AutoMoreira.Persistence.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _context;
        public ModeloRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Modelo[]> GetAllModelosAsync()
        {
            IQueryable<Modelo> query = _context.Modelos;

            query = query.AsNoTracking().OrderBy(m => m.ModeloId);

            return await query.ToArrayAsync();
        }

        public async Task<Modelo> GetModeloByIdAsync(int Id)
        {
            IQueryable<Modelo> query = _context.Modelos;


            query = query.AsNoTracking().OrderBy(p => p.ModeloId)
                         .Where(p => p.ModeloId == Id);

            return await query.FirstOrDefaultAsync();
        }

        //Rafael
        public async Task<Modelo[]> GetModeloByMarcaIdAsync(int marcaId)
        {
            IQueryable<Modelo> query = _context.Modelos;

            query = query.AsNoTracking().Where(x => x.MarcaId == marcaId).OrderBy(x => x.MarcaId);

            return await query.ToArrayAsync();
        }

    }
}
