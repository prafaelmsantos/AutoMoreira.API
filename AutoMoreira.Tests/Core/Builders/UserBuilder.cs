namespace AutoMoreira.Tests.Core.Builders
{
    public class UserBuilder
    {
        private static readonly Faker data = new("en");

        public static User User()
        {
            string email = data.Internet.Email();
            string phoneNumber = data.Phone.PhoneNumber();
            string firstName = data.Name.FirstName();
            string lastName = data.Name.LastName();

            return new(email, phoneNumber, firstName, lastName);
        }
        public static User FullUser()
        {
            int id = data.Random.Int(1);
            string email = data.Internet.Email();
            string phoneNumber = data.Phone.PhoneNumber();
            string firstName = data.Name.FirstName();
            string lastName = data.Name.LastName();
            bool isDefault = data.Random.Bool();

            return new(id, email, phoneNumber, firstName, lastName, isDefault);
        }
        public static UserDTO UserDTO()
        {
            return new()
            {
                Id = data.Random.Int(1),
                Email = data.Internet.Email(),
                PhoneNumber = data.Phone.PhoneNumber(),
                FirstName = data.Name.FirstName(),
                LastName = data.Name.LastName(),
                Image = data.Image.PlaceImgUrl(),
                Password = data.Random.Guid().ToString(),
                Token = data.Random.Guid().ToString(),
                DarkMode = data.Random.Bool(),
                IsDefault = data.Random.Bool(),
                Roles = new()
            };
        }
        public static UserLoginDTO UserLoginDTO(UserDTO userDTO)
        {
            return new()
            {
                Email = userDTO.Email,
                Password = userDTO.Password!
            };
        }
        public static User User(UserDTO dto)
        {
            return new(dto.Email, dto.PhoneNumber, dto.FirstName, dto.LastName);
        }
        public static User FullUser(UserDTO dto)
        {
            return new(dto.Id, dto.Email, dto.PhoneNumber, dto.FirstName, dto.LastName, dto.IsDefault);
        }
        public static List<User> UserList(User user)
        {
            return new List<User>() { user };
        }
        public static List<User> UserList(UserDTO dto)
        {
            return new List<User>() { User(dto) };
        }
        public static List<User> UserListWithRoles(UserDTO dto)
        {
            User user = User(dto);
            user.SetRoles(RoleBuilder.RoleList(dto.Roles.FirstOrDefault()!));
            return new List<User>() { user };
        }
        public static List<User> FullUserListWithRoles(UserDTO dto)
        {
            User user = FullUser(dto);
            user.SetRoles(RoleBuilder.RoleList(dto.Roles.FirstOrDefault()!));
            return new List<User>() { user };
        }
        public static List<UserDTO> UserListDTO(UserDTO dto)
        {
            return new List<UserDTO>() { dto };
        }
        public static List<User> FullUserListDTO(UserDTO dto)
        {
            return new List<User>() { FullUser(dto) };
        }
        public static IQueryable<User> IQueryable(UserDTO dto)
        {
            return UserList(dto).AsQueryable();
        }
        public static IQueryable<User> IQueryable(User user)
        {
            return UserList(user).AsQueryable();
        }
        public static IQueryable<User> IQueryableWithRoles(UserDTO dto)
        {
            return UserListWithRoles(dto).AsQueryable();
        }
        public static IQueryable<User> FullIQueryableWithRoles(UserDTO dto)
        {
            return FullUserListWithRoles(dto).AsQueryable();
        }
        public static IQueryable<User> IQueryableEmpty()
        {
            return new List<User>().AsQueryable();
        }
    }
}
