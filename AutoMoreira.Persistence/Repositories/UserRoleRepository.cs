namespace AutoMoreira.Persistence.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context) { }
    }
}
