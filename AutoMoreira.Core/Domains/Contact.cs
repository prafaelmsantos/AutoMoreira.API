namespace AutoMoreira.Core.Domains
{
    public class Contact
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Message { get; private set; }
        public DateTime DateTime { get; private set; }

    }
}
