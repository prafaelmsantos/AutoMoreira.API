namespace AutoMoreira.Core.Domains.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; private set; } = null!;
        public virtual Role Role { get; private set; } = null!;

        public UserRole(){ }

        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
