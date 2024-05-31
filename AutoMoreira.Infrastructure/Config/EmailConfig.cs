namespace AutoMoreira.Infrastructure.Config
{
    public class EmailConfig
    {
        public string Name { get; init; } = null!;
        public string Address { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string Host { get; init; } = null!;
        public int Port { get; init; }
    }
}
