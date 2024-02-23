namespace AutoMoreira.Core.Domains.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; private set; } = null!;
        public virtual Role Role { get; private set; } = null!;
    }
}
