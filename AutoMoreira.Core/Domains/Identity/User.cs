namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public bool DarkMode { get; private set; }

        //Um User pode ter muitas Roles
        public virtual IEnumerable<UserRole> UserRoles { get; private set; }
    }
}
