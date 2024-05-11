namespace AutoMoreira.Tests.Core.Builders
{
    public class VehicleBuilder
    {
        private static readonly Faker data = new("en");

        public static Vehicle Vehicle()
        {
            int modelId = data.Random.Int(1);
            string version = data.Vehicle.Model();
            FUEL fuelType = data.PickRandom<FUEL>();
            double price = data.Random.Double(0);
            int mileage = data.Random.Int(0);
            int year = data.Date.Recent(0).Year;
            string color = data.Commerce.Color();
            int doors = data.Random.Int(2, 5);
            TRANSMISSION transmission = data.PickRandom<TRANSMISSION>();
            int engineSize = data.Random.Int(0);
            int power = data.Random.Int(0);
            string observations = data.Lorem.Sentence();
            bool opportunity = data.Random.Bool();
            bool sold = data.Random.Bool();
            DateTime? soldDate = sold ? data.Date.Recent(0) : null;

            return new(modelId, version, fuelType, price, mileage, year, color, doors, transmission, engineSize, power, observations, opportunity, sold, soldDate);
        }
        public static Vehicle FullVehicle()
        {
            int id = data.Random.Int(1);
            int modelId = data.Random.Int(1);
            string version = data.Vehicle.Model();
            FUEL fuelType = data.PickRandom<FUEL>();
            double price = data.Random.Double(0);
            int mileage = data.Random.Int(0);
            int year = data.Date.Recent(0).Year;
            string color = data.Commerce.Color();
            int doors = data.Random.Int(2, 5);
            TRANSMISSION transmission = data.PickRandom<TRANSMISSION>();
            int engineSize = data.Random.Int(0);
            int power = data.Random.Int(0);
            string observations = data.Lorem.Sentence();
            bool opportunity = data.Random.Bool();

            return new(id, modelId, version, fuelType, price, mileage, year, color, doors, transmission, engineSize, power, observations, opportunity);
        }
        public static VehicleDTO VehicleDTO()
        {
            bool sold = data.Random.Bool();
            return new()
            {
                Id = data.Random.Int(1),
                ModelId = data.Random.Int(1),
                Version = data.Vehicle.Model(),
                FuelType = data.PickRandom<FUEL>(),
                Price = data.Random.Double(0),
                Mileage = data.Random.Int(0),
                Year = data.Date.Recent(0).Year,
                Color = data.Commerce.Color(),
                Doors = data.Random.Int(2, 5),
                Transmission = data.PickRandom<TRANSMISSION>(),
                EngineSize = data.Random.Int(0),
                Power = data.Random.Int(0),
                Observations = data.Lorem.Sentence(),
                Opportunity = data.Random.Bool(),
                Sold = sold,
                SoldDate = sold ? data.Date.Past() : null,
                VehicleImages = new()
            };
        }
        public static Vehicle Vehicle(VehicleDTO dto)
        {
            return new(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color, dto.Doors, dto.Transmission, dto.EngineSize,
                dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate);
        }
        public static Vehicle FullVehicle(VehicleDTO dto)
        {
            return new(dto.Id, dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color, dto.Doors, dto.Transmission, dto.EngineSize,
                dto.Power, dto.Observations, dto.Opportunity);
        }
        public static List<Vehicle> VehicleList(VehicleDTO dto)
        {
            return new List<Vehicle>() { Vehicle(dto) };
        }
        public static List<Vehicle> FullVehicleListDTO(VehicleDTO dto)
        {
            return new List<Vehicle>() { FullVehicle(dto) };
        }
        public static IQueryable<Vehicle> IQueryable(VehicleDTO dto)
        {
            return VehicleList(dto).AsQueryable();
        }
        public static IQueryable<Vehicle> IQueryableEmpty()
        {
            return new List<Vehicle>().AsQueryable();
        }
    }
}
