namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IMarkService
    {
        Task<MarkDTO> AddMark(MarkDTO markDTO);
        Task<MarkDTO> UpdateMark(int markId, MarkDTO markDTO);
        Task<bool> DeleteMark(int markId);

        Task<MarkDTO[]> GetAllMarksAsync();
        Task<MarkDTO> GetMarkByIdAsync(int markId);
    }
}
