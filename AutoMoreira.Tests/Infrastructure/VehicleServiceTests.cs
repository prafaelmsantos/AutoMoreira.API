namespace AutoMoreira.Tests.Infrastructure
{
    public class VehicleServiceTests : BaseClassTests
    {
        #region Private variables

        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly IVehicleService _vehicleService;

        #endregion

        #region Constructors

        public VehicleServiceTests(ITestOutputHelper output) : base(output)
        {
            AutoMoreira.Core.Mapper.AutoMapperProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            _vehicleRepositoryMock = new Mock<IVehicleRepository>(MockBehavior.Strict);
            _vehicleService = new VehicleService(Mapper, _vehicleRepositoryMock.Object);
        }

        #endregion

        #region GetAllVehiclesAsync

        [Fact]
        public async Task GetAllVehiclesAsync_GetAll_Successfully()
        {
            // Arrange   
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            List<VehicleDTO> result = await _vehicleService.GetAllVehiclesAsync();

            // Assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(VehicleBuilder.VehicleList(dto));

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllVehiclesAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetAllVehiclesAsync()).Should()
                .ThrowAsync<Exception>();
        }
        #endregion

        #region GetVehicleByIdAsync

        [Fact]
        public async Task GetVehicleByIdAsync_ValidModel_Successfully()
        {
            // Arrange   
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            VehicleDTO result = await _vehicleService.GetVehicleByIdAsync(dto.Id);

            // Assert
            result.Should().NotBeNull();
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

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetModelByIdAsync_VehicleNotFoundException_ThrowsExceptionAsync()
        {
            // Arrange   
            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryableEmpty()));

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetVehicleByIdAsync(It.IsAny<int>())).Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task GetModelByIdAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _vehicleRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetVehicleByIdAsync(It.IsAny<int>())).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region GetVehicleCountersAsync

        [Fact]
        public async Task GetVehicleCountersAsync_ValidValues_Successfully()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.SetupSequence(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)))
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)))
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            VehicleCounterDTO result = await _vehicleService.GetVehicleCountersAsync();

            // Assert
            result.Should().NotBeNull();

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Exactly(3));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetVehicleCountersAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _vehicleRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetVehicleCountersAsync()).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region GetAllVehiclesWithYearComparisonAsync

        [Fact]
        public async Task GetAllVehiclesWithYearComparisonAsync_ValidValues_Successfully()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.SetupSequence(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)))
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            ResponseCompleteStatisticDTO result = await _vehicleService.GetAllVehiclesWithYearComparisonAsync();

            // Assert
            result.Should().NotBeNull();

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Exactly(2));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllVehiclesWithYearComparisonAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _vehicleRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetAllVehiclesWithYearComparisonAsync()).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region GetAllVehiclesWithMonthComparisonAsync

        [Fact]
        public async Task GetAllVehiclesWithMonthComparisonAsync_ValidValues_Successfully()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            ResponseStatisticDTO result = await _vehicleService.GetAllVehiclesWithMonthComparisonAsync();

            // Assert
            result.Should().NotBeNull();

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllVehiclesWithMonthComparisonAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _vehicleRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetAllVehiclesWithMonthComparisonAsync()).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region GetVehiclePieStatisticsAsync

        [Fact]
        public async Task GetVehiclePieStatisticsAsync_ValidValues_Successfully()
        {
            // Arrange
            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;

            _vehicleRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Vehicle>(VehicleBuilder.IQueryable(dto)));

            // Act
            PieStatisticDTO result = await _vehicleService.GetVehiclePieStatisticsAsync();

            // Assert
            result.Should().NotBeNull();

            _vehicleRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetVehiclePieStatisticsAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _vehicleRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.GetVehiclePieStatisticsAsync()).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region AddVehicleAsync

        [Fact]
        public async Task AddVehicleAsync_ValidVehicle_Successfully()
        {
            // Arrange
            VehicleImageDTO vehicleImageDTO = VehicleImageBuilder.VehicleImageDTO();
            vehicleImageDTO.VehicleId = 0;
            vehicleImageDTO.Id = 0;
            vehicleImageDTO.IsMain = true;

            VehicleDTO dto = VehicleBuilder.VehicleDTO();
            dto.Id = 0;
            dto.VehicleImages = VehicleImageBuilder.VehicleImageDTOList(vehicleImageDTO);

            Vehicle vehicle = VehicleBuilder.Vehicle(dto);
            vehicle.SetVehicleImages(VehicleImageBuilder.VehicleImageList(vehicleImageDTO));

            _vehicleRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Vehicle>())).ReturnsAsync(VehicleBuilder.Vehicle(dto));

            // Act
            VehicleDTO result = await _vehicleService.AddVehicleAsync(dto);

            // Assert
            result.Should().NotBeNull();
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
            result.VehicleImages.Should().BeEquivalentTo(dto.VehicleImages).And.NotBeEmpty();

            _vehicleRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Vehicle>()), Times.Once);
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddVehicleAsync_AddAsyncNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            VehicleDTO dto = VehicleBuilder.VehicleDTO();

            _vehicleRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Vehicle>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _vehicleService.AddVehicleAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        #endregion
    }
}
