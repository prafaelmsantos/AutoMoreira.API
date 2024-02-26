namespace AutoMoreira.Core.Domains
{
    public class ClientMessage : EntityBase
    {
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public long PhoneNumber { get; private set; }
        public string Message { get; private set; } = null!;
        public STATUS Status { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public ClientMessage() { }

        public ClientMessage(string name, string email, long phoneNumber, string message)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
            Status = STATUS.Open;
            CreatedDate = DateTime.UtcNow;
        }

        public void SetStatus(STATUS status)
        {
            Status = status;
        }

    }
}
