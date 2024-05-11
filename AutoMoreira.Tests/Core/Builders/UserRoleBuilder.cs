namespace AutoMoreira.Tests.Core.Builders
{
    public class UserRoleBuilder
    {
        private static readonly Faker data = new("en");

        public static UserRole UserRole()
        {
            return new(data.Random.Int(1), data.Random.Int(1));
        }
        public static UserRole UserRole(int userId, int roleId)
        {
            return new(userId, roleId);
        }
        public static List<UserRole> UserRoleList(int userId, int roleId)
        {
            return new List<UserRole>() { UserRole(userId, roleId) };
        }
        public static IQueryable<UserRole> IQueryable(int userId, int roleId)
        {
            return UserRoleList(userId, roleId).AsQueryable();
        }
        public static IQueryable<UserRole> IQueryableEmpty()
        {
            return new List<UserRole>().AsQueryable();
        }
    }
}
