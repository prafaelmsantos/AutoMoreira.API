namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? Image { get; private set; }
        public bool DarkMode { get; private set; } = false;
        public bool IsDefault { get; private set; } = false;

        public virtual ICollection<Role> Roles { get; private set; }

        public User()
        {
            Roles = new List<Role>();
        }

        public User(int id, string email, string? phoneNumber, string firstName, string lastName, bool isDefault)
        {
            id.Throw(() => throw new Exception(DomainResource.UserIdNeedsToBeSpecifiedException))
            .IfNegativeOrZero();

            email.ThrowIfNull(() => throw new Exception(DomainResource.UserEmailNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            phoneNumber?.Throw(() => throw new Exception(DomainResource.UserPhoneNumberNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            firstName.ThrowIfNull(() => throw new Exception(DomainResource.UserFirstNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            lastName.ThrowIfNull(() => throw new Exception(DomainResource.UserLastNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Id = id;
            UserName = email;
            NormalizedUserName = email.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
            EmailConfirmed = true;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = true;
            FirstName = firstName;
            LastName = lastName;
            IsDefault = isDefault;

            Roles = new List<Role>();
        }

        public User(string email, string? phoneNumber, string firstName, string lastName)
        {
            email.ThrowIfNull(() => throw new Exception(DomainResource.UserEmailNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            phoneNumber?.Throw(() => throw new Exception(DomainResource.UserPhoneNumberNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            firstName.ThrowIfNull(() => throw new Exception(DomainResource.UserFirstNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            lastName.ThrowIfNull(() => throw new Exception(DomainResource.UserLastNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            UserName = email;
            NormalizedUserName = email.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
            EmailConfirmed = true;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumber != null;
            FirstName = firstName;
            LastName = lastName;
            IsDefault = false;

            Roles = new List<Role>();
        }

        public void UpdateUser(string email, string? phoneNumber, string firstName, string lastName, string? image)
        {
            email.ThrowIfNull(() => throw new Exception(DomainResource.UserEmailNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            phoneNumber?.Throw(() => throw new Exception(DomainResource.UserPhoneNumberNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            firstName.ThrowIfNull(() => throw new Exception(DomainResource.UserFirstNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            lastName.ThrowIfNull(() => throw new Exception(DomainResource.UserLastNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            image?.Throw(() => throw new Exception(DomainResource.UserImageNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            UserName = email;
            NormalizedUserName = email.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
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
            image.ThrowIfNull(() => throw new Exception(DomainResource.UserImageNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Image = image;
        }

        public void SetRoles(List<Role> roles)
        {
            Roles.Clear();
            Roles = roles;
        }

        public void SetPasswordHash(string passwordHash)
        {
            passwordHash.ThrowIfNull(() => throw new Exception(DomainResource.UserPasswordHashNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            PasswordHash = passwordHash;
            SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}
