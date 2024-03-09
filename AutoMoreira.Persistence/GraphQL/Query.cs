namespace AutoMoreira.Persistence.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] IUserRepository _repo)
        {
            return _repo.GetAll().Include(x => x.Roles);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Role> GetRoles([Service] IRoleRepository _repo)
        {
            return _repo.GetAll();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Vehicle> GetVehicles([Service] IVehicleRepository _repo)
        {
            return _repo
                .GetAll()
                .Include(x => x.VehicleImages)
                .Include(x => x.Model)
                .ThenInclude(x => x.Mark);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Mark> GetMarks([Service] IMarkRepository _repo)
        {
            return _repo.GetAll();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model> GetModels([Service] IModelRepository _repo)
        {
            return _repo.GetAll().Include(x => x.Mark);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ClientMessage> GetClientMessages([Service] IClientMessageRepository _repo)
        {
            return _repo.GetAll();
        }
    }
}
