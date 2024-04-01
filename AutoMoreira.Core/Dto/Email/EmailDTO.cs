namespace AutoMoreira.Core.Dto.Email
{
    public class EmailDTO
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }

    }
}
