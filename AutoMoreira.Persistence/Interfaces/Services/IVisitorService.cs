namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVisitorService
    {
        Task<ResponseVisitorDTO> GetAllVisitoresAsync(int? year);
        Task<VisitorDTO> CreateOrUpdateVisitorAsync(MONTH month);
    }
}
