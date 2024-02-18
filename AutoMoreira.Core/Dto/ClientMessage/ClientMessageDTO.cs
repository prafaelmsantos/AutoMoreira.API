namespace AutoMoreira.Core.Dto.ClientMessage
{
    public class ClientMessageDTO : EntityBaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool Open { get; set; }
    }
}

