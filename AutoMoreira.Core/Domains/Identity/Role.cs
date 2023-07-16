namespace AutoMoreira.Core.Domains.Identity
{
    public class Role : IdentityRole<int>
    {
        //Uma Role pode ter muitos Users
        public virtual IEnumerable<UserRole> UserRoles { get; private set; }
    }
}
