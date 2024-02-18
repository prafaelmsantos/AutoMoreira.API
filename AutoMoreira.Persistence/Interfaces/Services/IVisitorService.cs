namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVisitorService
    {
        Task<ResponseVisitorDTO> GetAllVisitoresAsync();
        Task<VisitorDTO> CreateOrUpdateVisitorAsync(MONTH month);
    }
}
