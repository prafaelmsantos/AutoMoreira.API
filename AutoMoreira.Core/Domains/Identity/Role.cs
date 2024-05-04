namespace AutoMoreira.Core.Domains.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<User> Users { get; private set; }

        public bool IsDefault { get; private set; } = false;
        public bool IsReadOnly { get; private set; } = false;

        public Role() 
        {
            Users = new List<User>();
        }

        public Role(int id, string name, bool isDefault = false, bool isReadOnly = false)
        {
            id.Throw(() => throw new Exception(DomainResource.RoleIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();

            name.ThrowIfNull(() => throw new Exception(DomainResource.RoleNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Id = id;
            Name = name;
            NormalizedName = name.ToUpper();
            IsDefault = isDefault;
            IsReadOnly = isReadOnly;

            Users = new List<User>();
        }

        public Role(string name)
        {
            name.ThrowIfNull(() => throw new Exception(DomainResource.RoleNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Name = name;
            NormalizedName = name.ToUpper();

            Users = new List<User>();
        }

        public void SetName(string name)
        {
            name.ThrowIfNull(() => throw new Exception(DomainResource.RoleNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Name = name;
            NormalizedName = name.ToUpper();
        }
    }
}
