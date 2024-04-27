namespace AutoMoreira.Tests.Core.Domains
{
    public class VisitorTests : BaseClassTests
    {
        public VisitorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange & Act
            Visitor visitor = VisitorBuilder.Visitor();

            // Assert
            visitor.Year.Should().Be(_faker.Date.RecentDateOnly().Year);
            visitor.Month.Should().Be((MONTH)_faker.Date.RecentDateOnly().Month);
            visitor.Value.Should().Be(1);
        }

        [Fact]
        public void TestMap_InitializesProperties()
        {
            // Arrange      
            Visitor visitor = VisitorBuilder.Visitor();
            VisitorDTO dto = VisitorBuilder.VisitorDTO(visitor);

            // Act
            Visitor result = _mapper.Map<Visitor>(dto);

            // Assert
            result.Year.Should().Be(visitor.Year);
            result.Month.Should().Be(visitor.Month);
            result.Value.Should().Be(visitor.Value);
        }

        [Fact]
        public void Method_SetValue_WithValidParameters()
        {
            // Arrange
            Visitor visitor = VisitorBuilder.Visitor();
            long value = visitor.Value + 1;

            // Act
            visitor.SetValue();

            // Assert
            visitor.Value.Should().Be(value);
        }
    }
}
