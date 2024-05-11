namespace AutoMoreira.Tests.Core.Domains
{
    public class MarkTests : BaseClassTests
    {
        public MarkTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();

            // Act
            Mark mark = MarkBuilder.Mark(dto);

            // Assert
            mark.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            mark.Models.Should().BeEmpty();
        }

        [Fact]
        public void Constructor_WithValidFullParameters_InitializesProperties()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();

            // Act
            Mark mark = MarkBuilder.FullMark(dto);

            // Assert
            mark.Id.Should().Be(dto.Id).And.BeGreaterThan(0);
            mark.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            mark.Models.Should().BeEmpty();
        }

        [Fact]
        public void TestMap_InitializesProperties()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            Mark mark = MarkBuilder.Mark(dto);

            // Act
            MarkDTO result = Mapper.Map<MarkDTO>(mark);

            // Assert
            result.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            mark.Models.Should().BeEmpty();
        }

        [Fact]
        public void TestMap_InitializesFullProperties()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            Mark mark = MarkBuilder.FullMark(dto);

            // Act
            MarkDTO result = Mapper.Map<MarkDTO>(mark);

            // Assert
            result.Id.Should().Be(dto.Id).And.BeGreaterThan(0);
            result.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            mark.Models.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FullConstructor_WithInvalidId_ThrowsArgumentException(int id)
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Id = id;

            // Act & Assert
            FluentActions.Invoking(() => MarkBuilder.FullMark(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FullConstructor_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Name = name!;

            // Act & Assert
            FluentActions.Invoking(() => MarkBuilder.FullMark(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkNameNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Name = name!;

            // Act & Assert
            FluentActions.Invoking(() => MarkBuilder.Mark(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkNameNeedsToBeSpecifiedException);
        }

        [Fact]
        public void SetName_WithValidParameters()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            Mark mark = MarkBuilder.Mark(dto);

            // Act
            mark.SetName(dto.Name);

            // Assert
            mark.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void SetName_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            Mark mark = MarkBuilder.Mark();

            // Act & Assert
            FluentActions.Invoking(() => mark.SetName(name!)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkNameNeedsToBeSpecifiedException);
        }
    }
}
