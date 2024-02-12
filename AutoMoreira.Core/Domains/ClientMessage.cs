namespace AutoMoreira.Core.Domains
{
    public class ClientMessage : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long PhoneNumber { get; private set; }
        public string Message { get; private set; }
        public DateTime DateTime { get; private set; }
        public bool Open { get; private set; }

        public ClientMessage() { }
    }
}
