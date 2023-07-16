namespace AutoMoreira.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(v => v.Id);

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                                 .FindAsync(id);          
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }

       
    }
}
