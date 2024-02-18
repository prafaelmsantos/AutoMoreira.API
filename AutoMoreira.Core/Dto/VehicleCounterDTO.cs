namespace AutoMoreira.Core.Dto
{
    public class VehicleCounterDTO
    {
        public SoldVehicleDTO Total { get; set; }
        public SoldVehicleDTO Month { get; set; }

        public int StockVehiclesUnits { get; set; }
        public double StockVehiclesValues { get; set; }
    }
}
