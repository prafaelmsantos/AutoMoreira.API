namespace AutoMoreira.Core.Dto
{
    public class VehicleDTO : EntityBaseDTO
    {
        public int ModelId { get; set; }
        public ModelDTO Model { get; set; }

        public string Version { get; set; }
        public string FuelType { get; set; }
        public double Price { get; set; }
        public double Mileage { get; set; }

        public int Year { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Transmission { get; set; }
        public int EngineSize { get; set; }
        public int Power { get; set; }
        public string Observations { get; set; }

        public bool Opportunity { get; set; }
        public bool Sold { get; set; }

    }
}
