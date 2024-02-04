namespace AutoMoreira.Core.Domains
{
    public class ClientMessage : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long PhoneNumber { get; private set; }
        public string Message { get; private set; }
        public DateTime DateTime { get; private set; }

        public ClientMessage() { }

        public ClientMessage(int id, string name, string email, long phoneNumber, string message)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
            DateTime = DateTime.UtcNow;
        }

        public ClientMessage(string name, string email, long phoneNumber, string message)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
            DateTime = DateTime.UtcNow;
        }
    }
}
