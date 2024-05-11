namespace AutoMoreira.Tests.Core.Builders
{
    public class ResponseMessageDTOBuilder
    {
        public static List<ResponseMessageDTO> ResponseMessageDTOList(string errorMessage, string? name = null, int id = 0)
        {
            return new() { new() {
                    Entity = new MinimumDTO() { Id = id, Name = name },
                    OperationSuccess = false,
                    ErrorMessage = errorMessage
                }
            };
        }
    }
}
