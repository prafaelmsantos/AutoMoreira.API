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

        public User(string userName, string email, string? phoneNumber, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Roles = new List<Role>();
        }

        public void UpdateUser(string userName, string email, string? phoneNumber, string firstName, string lastName, string? image, bool darkMode)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            DarkMode = darkMode;
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
