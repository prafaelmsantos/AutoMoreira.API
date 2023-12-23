namespace AutoMoreira.Persistence.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context) { }
    }
}
