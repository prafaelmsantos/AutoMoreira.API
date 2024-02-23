namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Image { get; private set; }
        public bool DarkMode { get; private set; } = false;
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public virtual ICollection<Role> Roles { get; private set; }

        public User()
        {
            Roles = new List<Role>();
        }

        public User(int id, string userName, string email, string? phoneNumber, string firstName, string lastName, Role role)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;

            SetRole(role);
        }

        public User(string userName, string email, string? phoneNumber, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
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
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetDarkMode(bool darkMode)
        {
            DarkMode = darkMode;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetImage(string image)
        {
            Image = image;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetRole(Role role)
        {
            Roles.Clear();
            Roles.Add(role);
        }


    }
}
