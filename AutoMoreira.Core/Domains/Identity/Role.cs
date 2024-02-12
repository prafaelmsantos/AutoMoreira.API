namespace AutoMoreira.Core.Domains.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<User> Users { get; private set; }
    }
}
