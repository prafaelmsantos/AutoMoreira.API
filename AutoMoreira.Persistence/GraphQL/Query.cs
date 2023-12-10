namespace AutoMoreira.Persistence.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Vehicle> GetVehicles([Service] IVehicleRepository _repo)
        {
            var vehicles = _repo.GetAllAsync().Result;
            return vehicles.AsQueryable();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Mark> GetMarks([Service] IMarkRepository _repo)
        {
            var marks = _repo.GetAllMarksAsync().Result;
            return marks.AsQueryable();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model> GetModels([Service] IModelRepository _repo)
        {
            var models = _repo.GetAllModelsAsync().Result;
            return models.AsQueryable();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Contact> GetContacts([Service] IContactRepository _repo)
        {
            var contacts = _repo.GetAllContactsAsync().Result;
            return contacts.AsQueryable();
        }
    }
}
