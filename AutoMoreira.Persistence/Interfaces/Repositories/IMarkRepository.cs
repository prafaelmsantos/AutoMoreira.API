namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IMarkRepository
    {
        Task<Mark[]> GetAllMarksAsync();
        Task<Mark> GetMarkByIdAsync(int markId);
    }
}
