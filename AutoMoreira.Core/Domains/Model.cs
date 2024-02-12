namespace AutoMoreira.Core.Domains
{
    public class Model : EntityBase
    {
        public string Name { get; private set; }
        public int MarkId { get; private set; }

        public virtual Mark Mark { get; private set; }

        public virtual ICollection<Vehicle> Vehicles { get; private set; }

        public Model()
        { 
        }

        public Model(string name, int markId)
        {
            Name = name;
            MarkId = markId;
        }

        public Model(int id, string name, int markId)
        {
            Id = id;
            Name = name;
            MarkId = markId;
        }
    }
}
