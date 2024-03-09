namespace AutoMoreira.Core.Dto.Generic
{
    public class ResponseMessageDTO
    {
        public MinimumDTO Entity { get; set; } = null!;
        public bool OperationSuccess { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }
}
