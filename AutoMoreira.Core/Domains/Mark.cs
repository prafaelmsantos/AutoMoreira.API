namespace AutoMoreira.Core.Domains
{
    public class Mark
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<Model> _models;
        public virtual ICollection<Model> Models => _models;

        private readonly List<Vehicle> _vehicles;
        public virtual ICollection<Vehicle> Vehicles => _vehicles;

        public Mark()
        {
            _models = new List<Model>();
            _vehicles = new List<Vehicle>();
        }

        public Mark(int id, string name)
        {
            Id = id;
            Name = name;

            _models = new List<Model>();
            _vehicles = new List<Vehicle>();
        }
    }
}
