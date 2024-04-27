namespace AutoMoreira.Tests.Core.Builders
{
    public class ClientMessageBuilder
    {
        private static readonly Faker _data = new("en");

        public static ClientMessage ClientMessage()
        {
            return new(_data.Person.FullName, _data.Person.Email, _data.Random.Long(200000000, 999999999), _data.Lorem.Text());
        }
        public static ClientMessageDTO ClientMessageDTO()
        {
            return new() { 
                Id = _data.Random.Int(1), 
                Name = _data.Person.FullName,
                Email = _data.Person.Email,
                PhoneNumber = _data.Random.Long(200000000, 999999999),
                Message = _data.Lorem.Text(),
                Status = _data.Random.Enum<STATUS>(),
                CreatedDate = DateTime.UtcNow
            };
        }
        public static ClientMessage ClientMessage(ClientMessageDTO dto)
        {
            return new(dto.Name, dto.Email, dto.PhoneNumber, dto.Message);
        }
        public static List<ClientMessage> ClientMessageList(ClientMessageDTO dto)
        {
            return new List<ClientMessage>() { ClientMessage(dto) };
        }
        public static List<ClientMessageDTO> ClientMessageDTO(ClientMessageDTO dto)
        {
            return new List<ClientMessageDTO>() { dto };
        }
        public static IQueryable<ClientMessage> IQueryable(ClientMessageDTO dto)
        {
            return ClientMessageList(dto).AsQueryable();
        }
        public static IQueryable<ClientMessage> IQueryableEmpty()
        {
            return new List<ClientMessage>().AsQueryable();
        }
        public static List<ResponseMessageDTO> ResponseMessageDTOList(ClientMessage clientMessage)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new() { 
                new ResponseMessageDTO {
                    Entity = new MinimumDTO() { Id = clientMessage.Id, Name = clientMessage.Name },
                    OperationSuccess = true,
                    ErrorMessage = null
                }
            };
            return responseMessageDTOs;
        }
    }
}
