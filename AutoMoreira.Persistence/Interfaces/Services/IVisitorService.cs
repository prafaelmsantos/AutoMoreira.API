namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVisitorService
    {
        Task<List<VisitorDTO>> GetAllVisitoresAsync();
        Task<VisitorDTO> CreateOrUpdateVisitorAsync(MONTH month);
    }
}
