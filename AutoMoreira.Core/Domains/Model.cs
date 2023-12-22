namespace AutoMoreira.Core.Domains
{
    public class Model : EntityBase
    {
        public string Name { get; private set; }
        public int MarkId { get; private set; }

        public virtual Mark Mark { get; private set; }


        private readonly List<Vehicle> _vehicles;
        public virtual ICollection<Vehicle> Vehicles => _vehicles;

        public Model()
        { 
            _vehicles = new List<Vehicle>(); 
        }

        public Model(int id, string name, int markId)
        {
            Id = id;
            Name = name;
            MarkId = markId;

            _vehicles = new List<Vehicle>();
        }
    }
}
