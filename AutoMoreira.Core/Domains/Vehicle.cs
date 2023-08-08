namespace AutoMoreira.Core.Domains
{
    public class Vehicle
    {
        public int Id { get; private set; }

        public int MarkId { get; private set; }
        public virtual Mark Mark { get; private set; }

        public int ModelId { get; private set; }
        public virtual Model Model { get; private set; }

        public string Version { get; private set; }
        public FUEL FuelType { get; private set; }
        public double Price { get; private set; }
        public double Mileage { get; private set; }
        
        public int Year { get; private set; }
        public string Color { get; private set; }
        public int Doors { get; private set; }
        public TRANSMISSION Transmission { get; private set; }
        public int EngineSize { get; private set; }
        public int Power { get; private set; }
        public string Observations { get; private set; }
        public bool New { get; private set; }
        public bool Opportunity { get; set; }
        public bool Sold { get; set; }

        private readonly List<VehicleImage> _vehicleImages;
        public virtual ICollection<VehicleImage> VehicleImages => _vehicleImages;

        public Vehicle() 
        {
            _vehicleImages = new List<VehicleImage>();
        }

        public Vehicle(int id, int markId, int modelId, string version, FUEL fuelType, 
            double price, double mileage, int year, string color, int doors, TRANSMISSION transmission, 
            int engineSize, int power, string observations, bool @new, bool opportunity, bool sold)
        {
            Id = id;
            MarkId = markId;
            ModelId = modelId;
            Version = version;
            FuelType = fuelType;
            Price = price;
            Mileage = mileage;
            Year = year;
            Color = color;
            Doors = doors;
            Transmission = transmission;
            EngineSize = engineSize;
            Power = power;
            Observations = observations;
            New = @new;
            Opportunity = opportunity;
            Sold = sold;

            _vehicleImages = new List<VehicleImage>();
        }
       
    }
}
