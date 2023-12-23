namespace AutoMoreira.Persistence.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Vehicle> GetVehicles([Service] IVehicleRepository _repo)
        {
            return _repo.GetAll();
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
            return _repo.GetAll();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Contact> GetContacts([Service] IContactRepository _repo)
        {
            return _repo.GetAll();
        }
    }
}
