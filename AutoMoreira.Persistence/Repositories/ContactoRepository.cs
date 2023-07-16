namespace AutoMoreira.Persistence.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly AppDbContext _context;
        public ContactoRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<Contacto[]> GetAllContactosAsync()
        {
            IQueryable<Contacto> query = _context.Contactos;

            query = query.AsNoTracking().OrderBy(v => v.ContactoId);

            return await query.ToArrayAsync();
        }

        public async Task<Contacto> GetContactoByIdAsync(int contactoId)
        {
            IQueryable<Contacto> query = _context.Contactos;


            query = query.AsNoTracking().OrderBy(p => p.ContactoId)
                         .Where(p => p.ContactoId == contactoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
