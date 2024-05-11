namespace AutoMoreira.Tests.Core.Domains
{
    public class VehicleTests : BaseClassTests
    {
        public VehicleTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();

            // Act
            Vehicle vehicle = VehicleBuilder.Vehicle(dto);

            // Assert
            vehicle.ModelId.Should().Be(dto.ModelId);
            vehicle.Version.Should().Be(dto.Version);
            vehicle.FuelType.Should().Be(dto.FuelType);
            vehicle.Price.Should().Be(dto.Price);
            vehicle.Mileage.Should().Be(dto.Mileage);
            vehicle.Year.Should().Be(dto.Year);
            vehicle.Color.Should().Be(dto.Color);
            vehicle.Doors.Should().Be(dto.Doors);
            vehicle.Transmission.Should().Be(dto.Transmission);
            vehicle.EngineSize.Should().Be(dto.EngineSize);
            vehicle.Power.Should().Be(dto.Power);
            vehicle.Observations.Should().Be(dto.Observations);
            vehicle.Opportunity.Should().Be(dto.Opportunity);
            vehicle.Sold.Should().Be(dto.Sold);
            vehicle.SoldDate.Should().Be(dto.SoldDate);
            vehicle.VehicleImages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Constructor_WithValidFullParameters_InitializesProperties()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();

            // Act
            Vehicle vehicle = VehicleBuilder.FullVehicle(dto);

            // Assert
            vehicle.Id.Should().Be(dto.Id);
            vehicle.ModelId.Should().Be(dto.ModelId);
            vehicle.Version.Should().Be(dto.Version);
            vehicle.FuelType.Should().Be(dto.FuelType);
            vehicle.Price.Should().Be(dto.Price);
            vehicle.Mileage.Should().Be(dto.Mileage);
            vehicle.Year.Should().Be(dto.Year);
            vehicle.Color.Should().Be(dto.Color);
            vehicle.Doors.Should().Be(dto.Doors);
            vehicle.Transmission.Should().Be(dto.Transmission);
            vehicle.EngineSize.Should().Be(dto.EngineSize);
            vehicle.Power.Should().Be(dto.Power);
            vehicle.Observations.Should().Be(dto.Observations);
            vehicle.Opportunity.Should().Be(dto.Opportunity);
            vehicle.VehicleImages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestMap_InitializesProperties()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            Vehicle vehicle = VehicleBuilder.Vehicle(dto);

            // Act
            VehicleDTO result = Mapper.Map<VehicleDTO>(vehicle);

            // Assert
            result.ModelId.Should().Be(dto.ModelId);
            result.Version.Should().Be(dto.Version);
            result.FuelType.Should().Be(dto.FuelType);
            result.Price.Should().Be(dto.Price);
            result.Mileage.Should().Be(dto.Mileage);
            result.Year.Should().Be(dto.Year);
            result.Color.Should().Be(dto.Color);
            result.Doors.Should().Be(dto.Doors);
            result.Transmission.Should().Be(dto.Transmission);
            result.EngineSize.Should().Be(dto.EngineSize);
            result.Power.Should().Be(dto.Power);
            result.Observations.Should().Be(dto.Observations);
            result.Opportunity.Should().Be(dto.Opportunity);
            result.Sold.Should().Be(dto.Sold);
            result.SoldDate.Should().Be(dto.SoldDate);
            result.VehicleImages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestMap_InitializesFullProperties()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            Vehicle vehicle = VehicleBuilder.FullVehicle(dto);

            // Act
            VehicleDTO result = Mapper.Map<VehicleDTO>(vehicle);

            // Assert
            result.ModelId.Should().Be(dto.ModelId);
            result.Version.Should().Be(dto.Version);
            result.FuelType.Should().Be(dto.FuelType);
            result.Price.Should().Be(dto.Price);
            result.Mileage.Should().Be(dto.Mileage);
            result.Year.Should().Be(dto.Year);
            result.Color.Should().Be(dto.Color);
            result.Doors.Should().Be(dto.Doors);
            result.Transmission.Should().Be(dto.Transmission);
            result.EngineSize.Should().Be(dto.EngineSize);
            result.Power.Should().Be(dto.Power);
            result.Observations.Should().Be(dto.Observations);
            result.Opportunity.Should().Be(dto.Opportunity);
            result.VehicleImages.Should().NotBeNull().And.BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FullConstructor_WithInvalidId_ThrowsArgumentException(int id)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = id;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FullConstructor_WithInvalidModelId_ThrowsArgumentException(int modelId)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.ModelId = modelId;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleModelIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void FullConstructor_WithInvalidFuelType_ThrowsArgumentException(int fuelType)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.FuelType = (FUEL)fuelType;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleFuelTypeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidPrice_ThrowsArgumentException(double price)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Price = price;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePriceNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidMileage_ThrowsArgumentException(int mileage)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Mileage = mileage;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleMileageNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidYear_ThrowsArgumentException(int year)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Year = year;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleYearNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidDoors_ThrowsArgumentException(int doors)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Doors = doors;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleDoorsNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void FullConstructor_WithInvalidTransmission_ThrowsArgumentException(int transmission)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Transmission = (TRANSMISSION)transmission;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleTransmissionNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidEngineSize_ThrowsArgumentException(int engineSize)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.EngineSize = engineSize;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleEngineSizeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void FullConstructor_WithInvalidPower_ThrowsArgumentException(int power)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Power = power;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.FullVehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePowerNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithInvalidModelId_ThrowsArgumentException(int modelId)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.ModelId = modelId;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleModelIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Constructor_WithInvalidFuelType_ThrowsArgumentException(int fuelType)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.FuelType = (FUEL)fuelType;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleFuelTypeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidPrice_ThrowsArgumentException(double price)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Price = price;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePriceNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidMileage_ThrowsArgumentException(int mileage)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Mileage = mileage;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleMileageNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidYear_ThrowsArgumentException(int year)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Year = year;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleYearNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidDoors_ThrowsArgumentException(int doors)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Doors = doors;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleDoorsNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Constructor_WithInvalidTransmission_ThrowsArgumentException(int transmission)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Transmission = (TRANSMISSION)transmission;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleTransmissionNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidEngineSize_ThrowsArgumentException(int engineSize)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.EngineSize = engineSize;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleEngineSizeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Constructor_WithInvalidPower_ThrowsArgumentException(int power)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Power = power;

            // Act & Assert
            FluentActions.Invoking(() => VehicleBuilder.Vehicle(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePowerNeedsToBeSpecifiedException);
        }

        [Fact]
        public void Update_WithValidParameters()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act
            vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color, dto.Doors, dto.Transmission, dto.EngineSize,
                dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate);

            // Assert
            vehicle.ModelId.Should().Be(dto.ModelId);
            vehicle.Version.Should().Be(dto.Version);
            vehicle.FuelType.Should().Be(dto.FuelType);
            vehicle.Price.Should().Be(dto.Price);
            vehicle.Mileage.Should().Be(dto.Mileage);
            vehicle.Year.Should().Be(dto.Year);
            vehicle.Color.Should().Be(dto.Color);
            vehicle.Doors.Should().Be(dto.Doors);
            vehicle.Transmission.Should().Be(dto.Transmission);
            vehicle.EngineSize.Should().Be(dto.EngineSize);
            vehicle.Power.Should().Be(dto.Power);
            vehicle.Observations.Should().Be(dto.Observations);
            vehicle.Opportunity.Should().Be(dto.Opportunity);
            vehicle.Sold.Should().Be(dto.Sold);
            vehicle.SoldDate.Should().Be(dto.SoldDate);
            vehicle.VehicleImages.Should().NotBeNull().And.BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Update_WithInvalidModelId_ThrowsArgumentException(int modelId)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.ModelId = modelId;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleModelIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Update_WithInvalidFuelType_ThrowsArgumentException(int fuelType)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.FuelType = (FUEL)fuelType;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleFuelTypeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidPrice_ThrowsArgumentException(double price)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Price = price;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePriceNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidMileage_ThrowsArgumentException(int mileage)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Mileage = mileage;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleMileageNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidYear_ThrowsArgumentException(int year)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Year = year;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleYearNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidDoors_ThrowsArgumentException(int doors)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Doors = doors;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleDoorsNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Update_WithInvalidTransmission_ThrowsArgumentException(int transmission)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Transmission = (TRANSMISSION)transmission;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleTransmissionNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidEngineSize_ThrowsArgumentException(int engineSize)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.EngineSize = engineSize;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleEngineSizeNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void Update_WithInvalidPower_ThrowsArgumentException(int power)
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Power = power;

            Vehicle vehicle = VehicleBuilder.Vehicle();

            // Act & Assert
            FluentActions.Invoking(() => vehicle.Update(dto.ModelId, dto.Version, dto.FuelType, dto.Price, dto.Mileage, dto.Year, dto.Color,
                dto.Doors, dto.Transmission, dto.EngineSize, dto.Power, dto.Observations, dto.Opportunity, dto.Sold, dto.SoldDate))
                .Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehiclePowerNeedsToBeSpecifiedException);
        }

        [Fact]
        public void SetVehicleImages_WithValidParameters()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            Vehicle vehicle = VehicleBuilder.Vehicle(dto);

            List<VehicleImage> vehicleImages = VehicleImageBuilder.VehicleImageList(VehicleImageBuilder.VehicleImageDTO());

            // Act
            vehicle.SetVehicleImages(vehicleImages);

            // Assert
            vehicle.VehicleImages.Should().BeEquivalentTo(vehicleImages);
        }

    }
}
