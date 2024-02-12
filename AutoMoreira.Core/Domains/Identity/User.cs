namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? ImageUrl { get; private set; }
        public bool DarkMode { get; private set; }

        public virtual ICollection<Role> Roles { get; private set; }

        public void SetDarkMode(bool darkMode)
        {
            DarkMode = darkMode;
        }


    }
}
