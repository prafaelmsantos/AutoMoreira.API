namespace AutoMoreira.Core.Domains
{
    public class Mark : EntityBase
    {
        public string Name { get; private set; } = null!;

        public virtual ICollection<Model> Models { get; private set; }

        public Mark()
        {
            Models = new List<Model>();
        }

        public Mark(int id, string name)
        {
            Id = id;
            Name = name;

            Models = new List<Model>();
        }

        public Mark(string name)
        {
            Name = name;

            Models = new List<Model>();
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
