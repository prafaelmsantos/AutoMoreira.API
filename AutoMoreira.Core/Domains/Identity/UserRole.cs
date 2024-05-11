namespace AutoMoreira.Core.Domains.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; private set; } = null!;
        public virtual Role Role { get; private set; } = null!;

        public UserRole() { }

        public UserRole(int userId, int roleId)
        {
            userId.Throw(() => throw new Exception(DomainResource.UserIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();

            roleId.Throw(() => throw new Exception(DomainResource.RoleIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();

            UserId = userId;
            RoleId = roleId;
        }
    }
}
