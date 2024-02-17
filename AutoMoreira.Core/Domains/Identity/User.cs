namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Image { get; private set; }
        public bool DarkMode { get; private set; }

        public virtual ICollection<Role> Roles { get; private set; }

        public User()
        {
            Roles = new List<Role>();
        }

        public void SetDarkMode(bool darkMode)
        {
            DarkMode = darkMode;
        }


    }
}
