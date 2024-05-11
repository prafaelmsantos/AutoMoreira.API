namespace AutoMoreira.Tests.Core.Builders
{
    public class ResponseMessageDTOBuilder
    {
        public static List<ResponseMessageDTO> ResponseMessageDTOList(string? errorMessage = null, int id = 0, string? name = null)
        {
            return new() { new() {
                    Entity = new MinimumDTO() { Id = id, Name = name },
                    OperationSuccess = errorMessage is null,
                    ErrorMessage = errorMessage
                }
            };
        }
    }
}
