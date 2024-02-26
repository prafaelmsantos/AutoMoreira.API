namespace AutoMoreira.Core.Domains.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<User> Users { get; private set; }

        public bool IsDefault { get; private set; }

        public Role() 
        {
            Users = new List<User>();
        }

        public Role(int id, string name, bool isDefault = false) 
        {
            Id = id;
            Name = name;
            IsDefault = isDefault;

            Users = new List<User>();
        }

        public Role(string name)
        {
            Name = name;

            Users = new List<User>();
        }

        public void UpdateRole(string name)
        {
            Name = name;
        }


    }
}
