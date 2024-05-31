namespace AutoMoreira.Infrastructure.Interfaces.Services
{
    public interface IMarkService
    {
        Task<List<MarkDTO>> GetAllMarksAsync();
        Task<MarkDTO> GetMarkByIdAsync(int markId);
        Task<MarkDTO> AddMarkAsync(MarkDTO markDTO);
        Task<MarkDTO> UpdateMarkAsync(MarkDTO markDTO);
        Task<List<ResponseMessageDTO>> DeleteMarksAsync(List<int> marksIds);
    }
}
