namespace AutoMoreira.Core.Dto
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        public int MarkId { get; set; }
        public virtual MarkDTO Mark { get; set; }

        public int ModelId { get; set; }
        public virtual ModelDTO Model { get; set; }

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
        public string ImageURL { get; set; }
        public bool New { get; set; }
        public bool Opportunity { get; set; }
        public bool Sold { get; set; }

    }
}
