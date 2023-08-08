namespace AutoMoreira.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<Contact[]> GetAllContactsAsync()
        {
            IQueryable<Contact> query = _context.Contacts;

            query = query.AsNoTracking().OrderBy(v => v.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            IQueryable<Contact> query = _context.Contacts;


            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == contactId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
