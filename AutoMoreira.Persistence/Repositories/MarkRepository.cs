namespace AutoMoreira.Persistence.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly AppDbContext _context;
        public MarkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Mark[]> GetAllMarksAsync()
        {
            IQueryable<Mark> query = _context.Marks;

            query = query.AsNoTracking().OrderBy(v => v.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Mark> GetMarkByIdAsync(int markId)
        {
            IQueryable<Mark> query = _context.Marks;


            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == markId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
