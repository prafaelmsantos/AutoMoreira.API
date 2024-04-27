namespace AutoMoreira.Tests.Core.Domains
{
    public class ModelTests : BaseClassTests
    {
        public ModelTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();

            // Act
            Model model = ModelBuilder.Model(dto);

            // Assert
            model.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            model.MarkId.Should().Be(dto.MarkId).And.BeGreaterThan(0);
            model.Mark.Should().Be(dto.Mark).And.BeNull();
            model.Vehicles.Should().BeEmpty();         
        }

        [Fact]
        public void Constructor_WithValidFullParameters_InitializesProperties()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();

            // Act
            Model model = ModelBuilder.FullModel(dto);

            // Assert
            model.Id.Should().Be(dto.Id).And.BeGreaterThan(0);
            model.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            model.MarkId.Should().Be(dto.MarkId).And.BeGreaterThan(0);
            model.Mark.Should().Be(dto.Mark).And.BeNull();
            model.Vehicles.Should().BeEmpty();
        }

        [Fact]
        public void TestMap_InitializesProperties()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            Model model = ModelBuilder.Model(dto);

            // Act
            ModelDTO result = _mapper.Map<ModelDTO>(model);

            // Assert
            result.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            result.MarkId.Should().Be(dto.MarkId).And.BeGreaterThan(0);
            result.Mark.Should().Be(dto.Mark).And.BeNull();
        }

        [Fact]
        public void TestMap_InitializesFullProperties()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            Model model = ModelBuilder.FullModel(dto);

            // Act
            ModelDTO result = _mapper.Map<ModelDTO>(model);

            // Assert
            result.Id.Should().Be(dto.Id).And.BeGreaterThan(0);
            result.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            result.MarkId.Should().Be(dto.MarkId).And.BeGreaterThan(0);
            result.Mark.Should().Be(dto.Mark).And.BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FullConstructor_WithInvalidId_ThrowsArgumentException(int id)
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = id;

            // Act & Assert
            FluentActions.Invoking(() => ModelBuilder.FullModel(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.ModelIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FullConstructor_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Name = name!;

            // Act & Assert
            FluentActions.Invoking(() => ModelBuilder.FullModel(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.ModelNameNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FullConstructor_WithInvalidMarkId_ThrowsArgumentException(int markId)
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.MarkId = markId;

            // Act & Assert
            FluentActions.Invoking(() => ModelBuilder.FullModel(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Name = name!;

            // Act & Assert
            FluentActions.Invoking(() => ModelBuilder.Model(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.ModelNameNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithInvalidMarkId_ThrowsArgumentException(int markId)
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.MarkId = markId;

            // Act & Assert
            FluentActions.Invoking(() => ModelBuilder.Model(dto)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkIdNeedsToBeSpecifiedException);
        }

        [Fact]
        public void Method_UpdateModel_WithValidParameters()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            Model model = ModelBuilder.Model(dto);

            // Act
            model.UpdateModel(dto.Name, dto.MarkId);

            // Assert
            model.Name.Should().Be(dto.Name).And.NotBeNullOrWhiteSpace();
            model.MarkId.Should().Be(dto.MarkId).And.BeGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Method_UpdateModel_WithInvalidName_ThrowsArgumentException(string? name)
        {
            // Arrange
            Model model = ModelBuilder.Model();

            // Act & Assert
            FluentActions.Invoking(() => model.UpdateModel(name!, model.MarkId)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.ModelNameNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Method_UpdateModel_WithInvalidMarkId_ThrowsArgumentException(int markId)
        {
            // Arrange
            Model model = ModelBuilder.Model();

            // Act & Assert
            FluentActions.Invoking(() => model.UpdateModel(model.Name, markId)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.MarkIdNeedsToBeSpecifiedException);
        }
    }
}
