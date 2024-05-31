namespace AutoMoreira.Infrastructure.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleDTO>> GetAllVehiclesAsync();
        Task<VehicleDTO> GetVehicleByIdAsync(int vehicleId);
        Task<VehicleCounterDTO> GetVehicleCountersAsync();
        Task<ResponseCompleteStatisticDTO> GetAllVehiclesWithYearComparisonAsync();
        Task<ResponseStatisticDTO> GetAllVehiclesWithMonthComparisonAsync();
        Task<PieStatisticDTO> GetVehiclePieStatisticsAsync();
        Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO);
        Task<VehicleDTO> UpdateVehicleAsync(VehicleDTO vehicleDTO);
        Task<List<ResponseMessageDTO>> DeleteVehiclesAsync(List<int> vehiclesIds);
    }
}
