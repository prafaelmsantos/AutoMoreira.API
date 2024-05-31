namespace AutoMoreira.Infrastructure.GraphQL
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:All members as static")]
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] IUserRepository repo)
        {
            return repo.GetAll().Include(x => x.Roles);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Role> GetRoles([Service] IRoleRepository repo)
        {
            return repo.GetAll();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Vehicle> GetVehicles([Service] IVehicleRepository repo)
        {
            return repo
                .GetAll()
                .Include(x => x.VehicleImages)
                .Include(x => x.Model)
                .ThenInclude(x => x.Mark);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Mark> GetMarks([Service] IMarkRepository repo)
        {
            return repo.GetAll();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model> GetModels([Service] IModelRepository repo)
        {
            return repo.GetAll().Include(x => x.Mark);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ClientMessage> GetClientMessages([Service] IClientMessageRepository repo)
        {
            return repo.GetAll();
        }
    }
}
