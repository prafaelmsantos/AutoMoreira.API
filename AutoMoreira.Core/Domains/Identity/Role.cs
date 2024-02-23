namespace AutoMoreira.Core.Domains.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<User> Users { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? LastModifiedDate { get; private set; }
        public bool IsDefault { get; private set; }

        public Role() 
        {
            Users = new List<User>();
        }

        public Role(int id, string name, bool isDefault = false) 
        {
            Id = id;
            Name = name;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            IsDefault = isDefault;

            Users = new List<User>();
        }

        public Role(string name)
        {
            Name = name;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;

            Users = new List<User>();
        }

        public void UpdateRole(string name)
        {
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }


    }
}
