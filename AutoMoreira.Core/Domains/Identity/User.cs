namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? Image { get; private set; }
        public bool DarkMode { get; private set; } = false;

        public virtual ICollection<Role> Roles { get; private set; }

        public User()
        {
            Roles = new List<Role>();
        }

        public User(string email, string? phoneNumber, string firstName, string lastName)
        {
            UserName = email;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Roles = new List<Role>();
        }

        public void UpdateUser(string email, string? phoneNumber, string firstName, string lastName, string? image)
        {
            UserName = email;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            Roles = new List<Role>();
        }

        public void SetDarkMode(bool darkMode)
        {
            DarkMode = darkMode;
        }

        public void SetImage(string image)
        {
            Image = image;
        }

        public void SetRoles(List<Role> roles)
        {
            Roles = roles;
        }

    }
}
