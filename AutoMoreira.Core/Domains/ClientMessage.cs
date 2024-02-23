namespace AutoMoreira.Core.Domains
{
    public class ClientMessage : AuditableEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long PhoneNumber { get; private set; }
        public string Message { get; private set; }
        public STATUS Status { get; private set; }

        public ClientMessage() { }

        public ClientMessage(string name, string email, long phoneNumber, string message)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
            Status = STATUS.Open;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetStatus(STATUS status)
        {
            Status = status;
            LastModifiedDate = DateTime.UtcNow;
        }

    }
}
