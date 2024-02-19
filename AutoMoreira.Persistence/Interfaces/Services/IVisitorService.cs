namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVisitorService
    {
        Task<ResponseVisitorDTO> GetAllVisitoresWithMonthComparisonAsync();
        Task<ResponseCompleteVisitorDTO> GetAllVisitoresWithYearComparisonAsync();
        Task<VisitorDTO> CreateOrUpdateVisitorAsync();
        Task<VisitorCounterDTO> GetAllVisitoresCountersAsync();
    }
}
