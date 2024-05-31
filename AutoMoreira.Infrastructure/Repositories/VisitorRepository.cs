namespace AutoMoreira.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(AppDbContext context) : base(context) { }
    }
}
