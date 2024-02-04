namespace AutoMoreira.Persistence.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public static IQueryable<User> GetUsers([Service] IUserRepository _repo)
        {
            return _repo.GetAll().Include(x => x.UserRoles);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public static IQueryable<Vehicle> GetVehicles([Service] IVehicleRepository _repo)
        {
            return _repo.GetAll().Include(x => x.Model).ThenInclude(x => x.Mark);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public static IQueryable<Mark> GetMarks([Service] IMarkRepository _repo)
        {
            return _repo.GetAll();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public static IQueryable<Model> GetModels([Service] IModelRepository _repo)
        {
            return _repo.GetAll().Include(x => x.Mark);
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public static IQueryable<Contact> GetContacts([Service] IContactRepository _repo)
        {
            return _repo.GetAll();
        }
    }
}
