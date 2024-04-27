namespace AutoMoreira.Tests.Core.Domains
{
    public class UserRoleTests : BaseClassTests
    {
        public UserRoleTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            int userId = _faker.Random.Int(1);
            int roleId = _faker.Random.Int(1);

            // Act
            UserRole userRole = UserRoleBuilder.UserRole(userId, roleId);

            // Assert
            userRole.UserId.Should().Be(userId);
            userRole.RoleId.Should().Be(roleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithInvalidUserId_ThrowsArgumentException(int userId)
        {

            // Act & Assert
            FluentActions.Invoking(() => UserRoleBuilder.UserRole(userId, _faker.Random.Int(1))).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.UserIdNeedsToBeSpecifiedException);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithInvalidRoleId_ThrowsArgumentException(int roleId)
        {

            // Act & Assert
            FluentActions.Invoking(() => UserRoleBuilder.UserRole(_faker.Random.Int(1), roleId)).Should()
                .Throw<Exception>()
                .WithMessage(DomainResource.RoleIdNeedsToBeSpecifiedException);
        }
    }
}
