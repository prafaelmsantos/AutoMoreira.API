namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVisitorService
    {
        Task<VisitorCounterDTO> GetVisitorCountersAsync();
        Task<ResponseVisitorDTO> GetAllVisitoresWithMonthComparisonAsync();
        Task<ResponseCompleteVisitorDTO> GetAllVisitoresWithYearComparisonAsync();


        Task<VisitorDTO> CreateOrUpdateVisitorAsync();     
    }
}
