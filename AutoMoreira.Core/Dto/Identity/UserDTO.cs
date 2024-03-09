namespace AutoMoreira.Core.Dto.Identity
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool DarkMode { get; set; }
        public bool IsDefault { get; set; }
        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
    }
}
