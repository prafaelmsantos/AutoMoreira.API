namespace AutoMoreira.Persistence.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(AppDbContext context) : base(context) { }
    }
}
