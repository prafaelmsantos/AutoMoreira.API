namespace AutoMoreira.Tests.Core.Builders
{
    public class VehicleBuilder
    {
        private static readonly Faker _data = new("en");

        public static Vehicle Vehicle()
        {
            int modelId = _data.Random.Int(1);
            string version = _data.Vehicle.Model();
            FUEL fuelType = _data.PickRandom<FUEL>();
            double price = _data.Random.Double(0);
            int mileage = _data.Random.Int(0);
            int year = _data.Date.Recent(0).Year;
            string color = _data.Commerce.Color();
            int doors = _data.Random.Int(2, 5);
            TRANSMISSION transmission = _data.PickRandom<TRANSMISSION>();
            int engineSize = _data.Random.Int(0);
            int power = _data.Random.Int(0);
            string observations = _data.Lorem.Sentence();
            bool opportunity = _data.Random.Bool();
            bool sold = _data.Random.Bool();
            DateTime? soldDate = sold ? _data.Date.Recent(0) : null;

            return new(modelId, version, fuelType, price, mileage, year, color, doors, transmission, engineSize, power, observations, opportunity, sold, soldDate);
        }
        public static Vehicle FullVehicle()
        {
            int id = _data.Random.Int(1);
            int modelId = _data.Random.Int(1);
            string version = _data.Vehicle.Model();
            FUEL fuelType = _data.PickRandom<FUEL>();
            double price = _data.Random.Double(0);
            int mileage = _data.Random.Int(0);
            int year = _data.Date.Recent(0).Year;
            string color = _data.Commerce.Color();
            int doors = _data.Random.Int(2, 5);
            TRANSMISSION transmission = _data.PickRandom<TRANSMISSION>();
            int engineSize = _data.Random.Int(0);
            int power = _data.Random.Int(0);
            string observations = _data.Lorem.Sentence();
            bool opportunity = _data.Random.Bool();

            return new(id, modelId, version, fuelType, price, mileage, year, color, doors, transmission, engineSize, power, observations, opportunity);
        }
        public static VehicleDTO VehicleDTO()
        {
            bool sold = _data.Random.Bool();
            return new() {
                Id = _data.Random.Int(1),
                ModelId = _data.Random.Int(1),
                Version = _data.Vehicle.Model(),
                FuelType = _data.PickRandom<FUEL>(),
                Price = _data.Random.Double(0),
                Mileage = _data.Random.Int(0),
                Year = _data.Date.Recent(0).Year,
                Color = _data.Commerce.Color(),
                Doors = _data.Random.Int(2, 5),
                Transmission = _data.PickRandom<TRANSMISSION>(),
                EngineSize = _data.Random.Int(0),
                Power = _data.Random.Int(0),
                Observations = _data.Lorem.Sentence(),
                Opportunity = _data.Random.Bool(),
                Sold = sold,
                SoldDate = sold ? _data.Date.Past() : null,
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
        public static List<ResponseMessageDTO> ResponseMessageDTOList(Vehicle vehicle)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new() { 
                new ResponseMessageDTO {
                    Entity = new MinimumDTO() { Id = vehicle.Id, Name = $"{vehicle.Model.Mark.Name} {vehicle.Model.Name}" + vehicle.Version != null ? $" {vehicle.Version}" : String.Empty },
                    OperationSuccess = true,
                    ErrorMessage = null
                }
            };
            return responseMessageDTOs;
        }
    }
}
