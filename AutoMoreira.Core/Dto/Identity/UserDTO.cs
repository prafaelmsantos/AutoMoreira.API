namespace AutoMoreira.Core.Dto.Identity
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool DarkMode { get; set; }
        public List<Role> Roles { get; set; }

    }
}
