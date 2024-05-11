namespace AutoMoreira.Tests.Core.Domains
{
    public class VehicleImageTests : BaseClassTests
    {
        public VehicleImageTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            VehicleImageDTO dto = VehicleImageBuilder.VehicleImageDTO();

            // Act
            VehicleImage vehicleImage = VehicleImageBuilder.VehicleImage(dto);

            // Assert
            vehicleImage.Url.Should().Be(dto.Url).And.NotBeNullOrWhiteSpace();
            vehicleImage.VehicleId.Should().Be(0);
            vehicleImage.IsMain.Should().BeFalse();
        }

        [Fact]
        public void TestMap_InitializesProperties()
        {
            // Arrange
            VehicleImageDTO dto = VehicleImageBuilder.VehicleImageDTO();
            VehicleImage vehicleImage = VehicleImageBuilder.VehicleImage(dto);

            // Act
            VehicleImageDTO result = Mapper.Map<VehicleImageDTO>(vehicleImage);

            // Assert
            result.Url.Should().Be(dto.Url).And.NotBeNullOrWhiteSpace();
            result.VehicleId.Should().Be(0);
            result.IsMain.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_WithInvalidName_ThrowsArgumentException(string? url)
        {
            // Arrange
            VehicleImageDTO dto = VehicleImageBuilder.VehicleImageDTO();
            dto.Url = url!;

            // Act & Assert
            FluentActions.Invoking(() => VehicleImageBuilder.VehicleImage(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.VehicleImageUrlNeedsToBeSpecifiedException);
        }

        [Fact]
        public void SetIsMain_WithValidParameters()
        {
            // Arrange
            VehicleImage VehicleImage = VehicleImageBuilder.VehicleImage();

            // Act
            VehicleImage.SetIsMain();

            // Assert
            VehicleImage.IsMain.Should().BeTrue();
        }
    }
}
