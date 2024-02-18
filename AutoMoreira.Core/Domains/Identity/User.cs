namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Image { get; private set; }
        public bool DarkMode { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public virtual ICollection<Role> Roles { get; private set; }

        public User()
        {
            Roles = new List<Role>();
        }

        public User(string userName, string email, string? phoneNumber, string firstName, string lastName, string? image, bool darkMode)
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


    }
}
