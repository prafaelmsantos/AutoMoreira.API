namespace AutoMoreira.Persistence.Repositories
{
    public class MarkRepository : Repository<Mark>, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context) { }
    }
}
