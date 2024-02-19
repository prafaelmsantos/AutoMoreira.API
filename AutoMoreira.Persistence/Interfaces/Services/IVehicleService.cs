namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO);
        Task<VehicleDTO> UpdateVehicleAsync(VehicleDTO vehicleDTO);
        Task<bool> DeleteVehicle(int vehicleId);

        Task<List<VehicleDTO>> GetAllVehiclesAsync();
        Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId);
        Task<VehicleCounterDTO> GetVehicleCountersAsync();
        Task<ResponseCompleteStatisticDTO> GetAllVisitoresWithYearComparisonAsync();
        Task<ResponseStatisticDTO> GetAllVehiclesWithMonthComparisonAsync();
        Task<PieStatisticDTO> GetVehiclePieStatisticsAsync();
    }
}
