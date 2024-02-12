namespace AutoMoreira.Core.Dto
{
    public class ClientMessageDTO : EntityBaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public bool Open { get; set; }
    }
}
