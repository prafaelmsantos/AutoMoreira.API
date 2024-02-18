namespace AutoMoreira.Core.Domains
{
    public class Mark : AuditableEntity
    {
        public string Name { get; private set; }

        public virtual ICollection<Model> Models { get; private set; }

        public Mark()
        {
            Models = new List<Model>();
        }

        public Mark(int id, string name)
        {
            Id = id;
            Name = name;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;

            Models = new List<Model>();
        }

        public Mark(string name)
        {
            Name = name;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;

            Models = new List<Model>();
        }

        public void SetName(string name)
        {
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
