namespace AutoMoreira.Tests.Core.Builders
{
    public class UserBuilder
    {
        private static readonly Faker _data = new("en");

        public static User User()
        {
            string email = _data.Internet.Email();
            string phoneNumber = _data.Phone.PhoneNumber();
            string firstName = _data.Name.FirstName();
            string lastName = _data.Name.LastName();

            return new(email, phoneNumber, firstName, lastName);
        }
        public static User FullUser()
        {
            int id = _data.Random.Int(1);
            string email = _data.Internet.Email();
            string phoneNumber = _data.Phone.PhoneNumber();
            string firstName = _data.Name.FirstName();
            string lastName = _data.Name.LastName();
            bool isDefault = _data.Random.Bool();

            return new(id, email, phoneNumber, firstName, lastName, isDefault);
        }
        public static UserDTO UserDTO()
        {
            return new() { 
                Id = _data.Random.Int(1), 
                Email = _data.Internet.Email(),
                PhoneNumber = _data.Phone.PhoneNumber(),
                FirstName = _data.Name.FirstName(),
                LastName = _data.Name.LastName(),
                Image = _data.Image.PlaceImgUrl(),
                Token = _data.Random.Guid().ToString(),
                DarkMode = _data.Random.Bool(),
                IsDefault = _data.Random.Bool(),
                Roles = new()
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
        public static List<User> UserList(UserDTO dto)
        {
            return new List<User>() { User(dto) };
        }
        public static List<User> FullUserListDTO(UserDTO dto)
        {
            return new List<User>() { FullUser(dto) };
        }
        public static IQueryable<User> IQueryable(UserDTO dto)
        {
            return UserList(dto).AsQueryable();
        }
        public static IQueryable<User> IQueryableEmpty()
        {
            return new List<User>().AsQueryable();
        }
        public static List<ResponseMessageDTO> ResponseMessageDTOList(User user)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new() { 
                new ResponseMessageDTO {
                    Entity = new MinimumDTO() { Id = user.Id, Name = user.Email },
                    OperationSuccess = true,
                    ErrorMessage = null
                }
            };
            return responseMessageDTOs;
        }
    }
}
